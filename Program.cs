using System;

namespace Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 1
            Converter conv = new Converter(usd: 0.088, eur: 0.075, rub: 6.49);
            System.Console.WriteLine("Введите в какую валюту хотите конвертировать сомони(usd,eur,rub) и сколько :");
            string currency = Console.ReadLine();
            double somons = double.Parse(Console.ReadLine());
            System.Console.WriteLine($"{somons} сомони было сконвертировано в {conv.ConvertTo(currency, somons)} {currency}");
            System.Console.WriteLine("\nВведите из какой валюты хотите сконвертировать в сомони(usd,eur,rub) и сколько :");
            currency = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());
            System.Console.WriteLine($"{money} {currency} было сконвертировано в {conv.ConvertFrom(currency, money)} сомони\n");

            //Задача 2
            Employee employ = new Employee("Tom", "Jerry") { post = "Middle", expYears = 2 };//2 года стажа
            employ.CalculateData(out double salary, out double NDS);
            System.Console.WriteLine($"{employ}\nОклад: {salary}\tНалоговый сбор: {NDS}");
        }
    }
    class Converter
    {
        private readonly double usd;
        private readonly double eur;
        private readonly double rub;
        public Converter(double usd, double eur, double rub)
        {
            this.usd = usd;
            this.eur = eur;
            this.rub = rub;
        }
        public double ConvertTo(string currency, double money) => currency.ToUpper() switch
        {
            "USD" => money * usd,
            "EUR" => money * eur,
            "RUB" => money * rub,
            _ => 0
        };
        public double ConvertFrom(string currency, double money) => currency.ToUpper() switch
        {
            "USD" => money / usd,
            "EUR" => money / eur,
            "RUB" => money / rub,
            _ => 0
        };
    }
    class Employee
    {
        private readonly string name;
        private readonly string surName;
        public double expYears { get; init; }//стаж работы в годах
        public string post { get; init; }
        public Employee(string name, string surName)
        {
            this.name = name;
            this.surName = surName;
        }
        public void CalculateData(out double salary, out double NDS)
        {
            salary = post switch
            {
                "Junior" => 1000 + expYears * 500,
                "Middle" => 2000 + expYears * 700,
                "Senior" => 3000 + expYears * 1000,
                _ => 0
            };
            NDS = salary / 100 * 14;
        }
        public override string ToString() => $"Имя: {name}\tФамилия: {surName}\tДолжность: {post}";
    }
}
