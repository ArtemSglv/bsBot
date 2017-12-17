using System;
using System.Collections.Generic;
using System.Linq;
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

    static class Bot
    {
        public static Exchange currentExchange; // = new ExYobit(); // временно
        public static string currentMarket = string.Empty;
        public static OrderLimit orderLimit = new OrderLimit();
        public static TimeOut timeout = new TimeOut();
        public static bool IsStarted;
        public static Mutex getBalanceMutex = new Mutex();
        public static choiceExchange mainForm;

        static Thread threadTrade;
        //static Thread mainOperTrade;
        static Random rnd = new Random();
        static FileStream fs;
        static StreamWriter sw;
        static double price = 0;
        static double amount = 0;
        //static object locker = new object();

        public static void StartTrade(Thread trd)
        {
            IsStarted = true;
            threadTrade = new Thread(delegate () { trd.Join(); try { Trade(); } catch { } })
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

        private static void Trade()
        {
            fs = new FileStream("Log.txt", FileMode.OpenOrCreate);
            fs.Seek(fs.Length, SeekOrigin.Current);
            sw = new StreamWriter(fs);
            do
            {                
                // startBalance already exsist
                // trade
                GetPrice();
                if (currentExchange.price.diff() > currentExchange.min_rate[currentMarket])
                {
                    //trade
                    switch (rnd.Next(0, 2))
                    {
                        case 0:
                            {
                                price = currentExchange.price.bid + currentExchange.min_rate[currentMarket];
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                Trade_oper(TypeOrder.buy, price, amount);
                                Trade_oper(TypeOrder.sell, price, amount);
                                break;
                            }
                        case 1:
                            {
                                price = currentExchange.price.ask - currentExchange.min_rate[currentMarket];
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                //mainOperTrade = new Thread(delegate () { Trade_oper(TypeOrder.sell, price, amount); })
                                //{
                                //Name = "Thread MainOper: " + TypeOrder.sell.ToString(),
                                //IsBackground = true
                                //};
                                //mainOperTrade.Start();
                                Trade_oper(TypeOrder.sell, price, amount);
                                Trade_oper(TypeOrder.buy, price, amount);
                                break;
                            }
                    }

                    //curBalance
                    //try
                    //{
                        GetBalance();
                    //}
                    //catch (WebException wex)
                    //{
                    //    mainForm.printLog("Get Balance "+DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + wex.Message + "\n");
                    //}

                    // if balance is not norm then stop trade
                    var coin = GetCoin(currentMarket);
                    if (currentExchange.startBalance != null && currentExchange.curBalance != null &&
                        (currentExchange.startBalance[coin] != currentExchange.curBalance[coin]))
                    {
                        var s = "Стартовый баланс: " + currentExchange.startBalance[coin] + " Текущий баланс: " +
                            currentExchange.curBalance[coin] +
                            "\nИзменение баланса. Операция остановлена\n";
                        mainForm.printLog(s);
                        sw.Write(s);

                        //sw.Close();
                        //fs.Close();
                        break;
                    }
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
