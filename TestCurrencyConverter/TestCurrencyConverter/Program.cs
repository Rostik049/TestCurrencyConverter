using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace ConsoleApplication1
{
    enum Currency
    {
        USD = 0,
        EUR,
        BIT
    };

    class Money
    {
        private double item;
        private double usd;
        private double uah;
        private double eur;
        private double bit;
        private double usdSale;
        private double eurSale;
        private double bitSale;
        private double k;
        private string currency;
        private string currency1;
        public Money(string currency, string currency1, double item,double usd,double uah,double eur,double bit,double usdSale,double eurSale,double bitSale)
        {
            this.currency = currency;
            this.currency1 = currency1;
            this.item = item;
            this.usd = usd;
            this.uah = uah;
            this.eur = eur;
            this.bit = bit;
            this.usdSale = usdSale;
            this.eurSale = eurSale;
            this.bitSale = bitSale;
        }
        public void Transfer()
        {
            double res = 0;
            if (currency == "USD" && currency1 == "UAH")
            {
                k = usd;
            }
            else if (currency == "USD" && currency1 == "EUR")
            {
                k = usdSale / eurSale;
            }
            else if (currency == "USD" && currency1 == "BIT")
            {
                k = usdSale / bitSale;
            }
            else if (currency == "UAH" && currency1 == "USD")
            {
                k = uah / usdSale;
            }
            else if (currency == "UAH" && currency1 == "EUR")
            {
                k = uah / eurSale;
            }
            else if (currency == "UAH" && currency1 == "BIT")
            {
                double dollar;
                dollar = uah / usdSale;
                k = dollar / bitSale;
            }
            else if (currency == "EUR" && currency1 == "UAH")
            {
                k = eur;
            }
            else if (currency == "EUR" && currency1 == "USD")
            {
                k = eur / usd;
            }
            else if (currency == "EUR" && currency1 == "BIT")
            {
                double dollar;
                dollar = eur / usd;
                k = dollar / bitSale;
            }
            else if (currency == "BIT" && currency1 == "USD")
            {
                k = bit;
            }
            else if (currency == "BIT" && currency1 == "EUR")
            {
                double dollar;
                dollar = eur / usd;
                k = bit / dollar;
            }
            else if (currency == "BIT" && currency1 == "UAH")
            {
                double dollar;
                dollar = uah / usd;
                k = dollar / bit;
            }
            res = item * k;
            Console.WriteLine(res);
        }
        public void Print()
        {
            Console.Write(currency + " = ");
            Console.WriteLine(item);
            Console.Write(currency1 + " = ");
            Transfer();
        }
    }
    class Todo
    {
        public string ccy { get; set; }
        public string base_ccy { get; set; }
        public string buy { get; set; }
        public string sale { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
        NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
        };
        HttpClient client = new HttpClient();
         string responce = await client.GetStringAsync(
               "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5"
           );
        List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(responce);
         double usd = Convert.ToDouble(todo[0].buy, numberFormatInfo);
         double uah = 1;
         double eur = Convert.ToDouble(todo[1].buy, numberFormatInfo);
         double bit = Convert.ToDouble(todo[2].buy, numberFormatInfo);
         double usdSale = Convert.ToDouble(todo[0].sale, numberFormatInfo);
         double eurSale = Convert.ToDouble(todo[1].sale, numberFormatInfo);
         double bitSale = Convert.ToDouble(todo[2].sale, numberFormatInfo);
         double item;
         string cur, cur1;
         Console.WriteLine("Enter the value of first currensy: ");
         cur = Console.ReadLine();
         Console.WriteLine("Enter the value of second currensy: ");
         cur1 = Console.ReadLine();
         Console.WriteLine("Enter the value of money: ");
         item = Convert.ToDouble(Console.ReadLine());
         Money mon = new Money(cur, cur1, item,usd,uah,eur,bit,usdSale,eurSale,bitSale);
         mon.Print();
        }
    }
}
