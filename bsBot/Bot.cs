using System;
using System.Collections.Generic;
using System.Media;
using System.Net;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;

namespace bsBot
{
    struct OrderLimit
    {
        public double min;
        public double max;
    }
    struct TimeOut
    {
        public int min;
        public int max;
    }
    enum TypeOrder
    {
        sell = 1,
        buy = 0
    }
    enum TypeOper
    {
        Buy = 0,
        Sell = 1,
        Random = 2
    }
    enum TypeSpread
    {
        Min = 0,
        Manual = 1,
        Dynamic = 2
    }

    static class Bot
    {
        public static Exchange currentExchange; // = new ExYobit(); // временно
        public static string currentMarket = string.Empty;
        public static OrderLimit orderLimit = new OrderLimit();
        public static TimeOut timeout = new TimeOut();
        public static bool IsStarted;
        public static Mutex getBalanceMutex = new Mutex();
        public static choiceExchange mainForm;
        public static double MaxDiffBalance = 0;
        public static TypeOper botTypeOper = TypeOper.Random;
        public static TypeSpread botTypeSpread = TypeSpread.Min;

        static Thread threadTrade;
        //static Thread mainOperTrade;
        static Random rnd = new Random();
        static FileStream fs;
        static StreamWriter sw;
        static double price = 0;
        static double amount = 0;
        static double PriceOffset;
        //static object locker = new object();

        public static void StartTrade(Thread trd)
        {
            IsStarted = true;
            threadTrade = new Thread(delegate () { trd.Join(); try { Trade(); } catch (Exception ex) { sw.Write(DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff")+" "+ex.Message+"\n"); } })
            {
                Name = "Trade",
                IsBackground = true
            }; // пустой catch ОЧЕНЬ ПЛОХО!!
            threadTrade.Start();
        }
        public static void StopTrade()
        {
            IsStarted = false;
            //mainOperTrade.Abort();
            threadTrade.Abort();
            sw.Close();
            fs.Close();
            mainForm.ChangeTitle();
        }
        public static void GetMarkets()
        {
            currentExchange.GetMarkets();
        }
        public static void GetBalance()
        {
            currentExchange.curBalance = currentExchange.GetBalance("", GetNonce());
        }
        public static void GetStartBalance()
        {
            currentExchange.startBalance = currentExchange.GetBalance("", GetNonce()); //for all currency
        }

        private static void GetPrice()
        {
            currentExchange.GetPrice(currentMarket);
        }
        private static void ChangeConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["nonce"].Value = (int.Parse(config.AppSettings.Settings["nonce"].Value) + 1).ToString();
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private static int GetNonce()
        {
            int nonce = int.Parse(ConfigurationManager.AppSettings["nonce"]);
            ChangeConfig();
            return nonce;
        }
        private static double GetRandomNumber(double minimum, double maximum)
        {
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }
        private static string GetCoin(string market)
        {
            string pattern = @"\w+(?=_)";
            Regex r = new Regex(pattern);
            return r.Match(market).Value;
        }

        private static void Trade_oper(TypeOrder type, double price, double amount) //buy: bid + min_rate; sell: ask - min_rate
        {
            string str = string.Empty;
            try
            {
                str = currentExchange.Trade(type, currentMarket, price, amount, GetNonce());

            }
            catch (WebException wex)
            {
                //lock (locker)
                //{
                mainForm.printLog("Trade oper " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + wex.Message + "\n");
                sw.Write("Trade oper " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + wex.Message + "\n");
                //}
                return;
            }
            //lock (locker)
            //{
            mainForm.printLog(str);
            sw.Write(str);

            //}

        }

        private static bool CheckBalance()
        {
            GetBalance();

            var coin = GetCoin(currentMarket);
            if (currentExchange.startBalance != null && currentExchange.curBalance != null && currentExchange.startBalance.ContainsKey(coin) &&
                currentExchange.curBalance.ContainsKey(coin) &&
                Math.Round(Math.Abs(currentExchange.startBalance[coin] - currentExchange.curBalance[coin]), 8) > MaxDiffBalance)
            {
                var s = "Стартовый баланс: " + currentExchange.startBalance[coin] + " Текущий баланс: " +
                    currentExchange.curBalance[coin] +
                    "\nИзменение баланса. Операция остановлена\n";
                mainForm.printLog(s);
                sw.Write(s);
                return true;
            }
            return false;
        }
        private static bool CheckPrice()
        {
            GetPrice();
            return currentExchange.price.diff() > currentExchange.min_rate[currentMarket];
        }
        private static void Trade()
        {
            fs = new FileStream("Log.txt", FileMode.OpenOrCreate);
            fs.Seek(fs.Length, SeekOrigin.Current);
            sw = new StreamWriter(fs);
            PriceOffset= currentExchange.min_rate[currentMarket];
            do
            {
                // startBalance already exsist
                
                if (CheckPrice())
                {
                    //trade
                    int flag = (int)botTypeOper <= 1 ? (int)botTypeOper : rnd.Next(0, 2);
                    switch (flag)
                    {
                        case 0:
                            {
                                price = currentExchange.price.bid + PriceOffset;
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                Trade_oper(TypeOrder.buy, price, amount);
                                Trade_oper(TypeOrder.sell, price, amount);
                                break;
                            }
                        case 1:
                            {
                                price = currentExchange.price.ask - PriceOffset;
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                Trade_oper(TypeOrder.sell, price, amount);
                                Trade_oper(TypeOrder.buy, price, amount);
                                break;
                            }
                    }

                    // if balance is not norm then stop trade
                    if (CheckBalance()) //true if diff   
                    {
                        IsStarted = false;
                        mainForm.BotStatus(IsStarted);
                        mainForm.Notify();
                        break;
                    }
                }
                else
                {
                    mainForm.printLog(DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " Invalid spread\n");
                    sw.Write(DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " Invalid spread\n");
                }

                mainForm.ChangeTitle("Пауза...");
                Thread.Sleep(rnd.Next(timeout.min, timeout.max + 1));
                mainForm.ChangeTitle();
            } while (IsStarted);

            sw.Close();
            fs.Close();
        }
    }
}
