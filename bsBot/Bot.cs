using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static Thread threadTrade;
        static Random rnd = new Random();
        static FileStream fs;
        static StreamWriter sw;
        static double price = 0;
        static double amount = 0;
        static Log log;

        static void Buy(double price, double amount) // bid + min_rate
        {
            string str = currentExchange.Trade(TypeOrder.buy, currentMarket, price, amount, GetNonce());
            sw.Write(str);
            log.Invoke(new Action(() => { log.printLog(str); }));
        }

        static void Sell(double price, double amount) // ask - min_rate
        {
            string str = currentExchange.Trade(TypeOrder.sell, currentMarket, price, amount, GetNonce());
            sw.Write(str);
            log.Invoke(new Action(() => { log.printLog(str); }));
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

        static void Trade()
        {
            do
            {
                fs = new FileStream("log.txt", FileMode.OpenOrCreate);
                fs.Seek(fs.Length, SeekOrigin.Current);
                sw = new StreamWriter(fs);
                // startBalance already is exsist
                // trade
                GetPrice();
                if (currentExchange.price.diff() > currentExchange.min_rate[currentMarket])
                {
                    switch (rnd.Next(0, 2))
                    {
                        case 0:
                            {
                                price = currentExchange.price.bid + currentExchange.min_rate[currentMarket];
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                Buy(price, amount);
                                Sell(price, amount);
                                break;
                            }
                        case 1:
                            {
                                price = currentExchange.price.ask - currentExchange.min_rate[currentMarket];
                                amount = GetRandomNumber(orderLimit.min, orderLimit.max + 1);
                                Sell(price, amount);
                                Buy(price, amount);
                                break;
                            }
                    }

                    // if balance is not norm then stop trade
                    var coin = GetCoin(currentMarket);
                    if (currentExchange.startBalance != null && currentExchange.curBalance != null && 
                        (currentExchange.startBalance[coin] != currentExchange.curBalance[coin]))
                    {
                        var s = "Стартовый баланс: " + currentExchange.startBalance[coin] + " Текущий баланс: " +
                            currentExchange.curBalance[coin] +
                            "\nПокупка/продажа не у себя повлекла изменение баланса. Торговля остановлена\n";
                        log.Invoke(new Action(() =>
                        {
                            log.printLog(s);
                        }));
                        sw.Write(s);

                        sw.Close();
                        fs.Close();
                        break;
                    }
                }

                sw.Close();
                fs.Close();
                Thread.Sleep(rnd.Next(timeout.min, timeout.max + 1));
            } while (IsStarted);

        }

        public static void StartTrade()
        {
            IsStarted = true;
            threadTrade = new Thread(delegate () { Trade(); });
            threadTrade.Start();
            log = new Log();
            log.Show();

        }

        public static void StopTrade()
        {
            IsStarted = false;
            log.Close();
        }

        public static void GetMarkets()
        {
            currentExchange.GetMarkets();
        }

        static void GetPrice()
        {
            currentExchange.GetPrice(currentMarket);
        }

        public static string GetInfo()
        {
            return currentExchange.GetInfo(currentMarket, GetNonce());
        }
    }
}
