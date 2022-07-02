using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace ConsoleApplication1
{
    enum Currency {USD,EUR,BIT,UAH};
    class Money 
    {
        private double item;
        private double usd = 35.3;
        private double uah = 1;
        private double eur = 36.7;
        private double bit = 19023.1913;
        private double k;
        private Currency currency;
        private Currency currency1;
        public Money(Currency currency,Currency currency1,double item)
        {
            this.currency = currency;
            this.currency1 = currency1;
            this.item = item;
        }
        public void Transfer()
        {
            double res = 0 ;
            if(currency == Currency.USD && currency1 == Currency.UAH)
            {
                k = usd;
            }
            else if (currency == Currency.UAH && currency1 == Currency.USD)
            {
                k = uah/usd;
            }
            else if (currency == Currency.EUR && currency1 == Currency.UAH)
            {
                k = eur;
            }
            else if (currency == Currency.UAH && currency1 == Currency.EUR)
            {
                k = uah/eur;
            }
            else if (currency == Currency.USD && currency1 == Currency.EUR)
            {
                k = usd / eur;
            }
            else if (currency == Currency.EUR && currency1 == Currency.USD)
            {
                k = eur / usd;
            }
            res = item * k;
            Console.WriteLine(res);
        }
        public void Print()
        {
            Console.Write(currency  +" = ");
            Console.WriteLine(item);
            Console.Write(currency1 +" = ");
            Transfer();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double item;
            item = Convert.ToDouble(Console.ReadLine());
            Money mon = new Money(Currency.EUR,Currency.UAH,item);
            mon.Print();
        }
    }
}
