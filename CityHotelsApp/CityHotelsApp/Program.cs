using System;
using System.Linq;

namespace CityHotelsApp
{
    class Program
    {
        //Aleksei Kromski JPTVR18
        class Hotels
        {
            public string city { get; set; }
            public string hotel_name { get; set; }
            public string address { get; set; }
            public string services { get; set; }

            //Конструктор
            public Hotels(string city, string hotel_name, string address, string services)
            {
                this.city = city;
                this.hotel_name = hotel_name;
                this.address = address;
                this.services= services;
            }

            public override string ToString()
            {
                return $"City: {city}, Hotel: {hotel_name}, Address: {address}, Services: {services}";
            }

        }
        static void Main(string[] args)
        {
            //Создание объектов идет через конструктор класса
            Hotels[] hotels =
            {
                new Hotels("Tallinn","Hilton","Tallinna pst 23","WIFI, Parking"),
                new Hotels("Tallinn","Merres","Tallinna mnt 01","WIFI"),
                new Hotels("Tallinn","Junina","Tallinna pst 22","WIFI, Bar, Parking"),
                new Hotels("Tartu","Messia","Tartu center 22","WIFI, Bar, Parking"),
                new Hotels("Tartu","Tartu center hostel","Tartu mnt 41","WIFI, Bar, Parking"),
                new Hotels("Parnu","Parnu hostel","Parnu mnt 14","Parking"),
                new Hotels("Parnu","Parnu Hiusa hostel","Parnu heina 28","Parking"),
                new Hotels("Toila","Toila spa hotel","Toila raida 13","WIFI, Parking, SPA"),
            };

            //Выводим все отели
            int count = 0;
            Console.WriteLine("==== ALL HOTELS ====");
            foreach(Hotels h in hotels)
            {
                count++;
                Console.WriteLine($"{count}. {h.ToString()}");
            }

            //Выводим отели Таллинна
            count = 0;
            Console.WriteLine("\n==== Tallinn HOTELS ====");
            var selectedTallinnHotels = from h in hotels
                                        where h.city == "Tallinn"
                                        select h;

            foreach (Hotels h in selectedTallinnHotels)
            {
                count++;
                Console.WriteLine($"{count}. {h.ToString()}");
            }

            Console.ReadKey();
        }
    }
}
