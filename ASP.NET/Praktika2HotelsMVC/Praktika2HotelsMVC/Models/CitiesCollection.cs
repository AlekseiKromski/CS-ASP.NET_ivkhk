using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Praktika2HotelsMVC.Models
{
    public class CitiesCollection
    {
        public static List<City> listCities = new List<City>();

        static CitiesCollection()
        {
            listCities.Add(new City
            {
                id = 1,
                Title = "Tallinn",
                Hotels = new List<Hotel>()
                {
                new Hotel {id = 1 , name = "Radisson Blu Sky Hotel", services = "Free Wifi Restaurant", img = "Radisson.png", address = "Ravala Puiestee 3"},
                new Hotel {id = 2 , name = "Hotel Palace", services = "Breakfast Included Free Internett", img = "Palace.png", address = "Vabaduse Valjak 3"},
                new Hotel {id = 3 , name = "Nordic Hotel", services = "Reserve now, pay later Breakfast Included Free Internet", img = "Forum.PNG", address = "Ravala Puiestee 3"}
                }
            });
            listCities.Add(new City
            {
                id = 2,
                Title = "Tartu",
                Hotels = new List<Hotel>()
                {
                new Hotel {id = 4 , name = "Art Hotel Pallas", services = "Air conditioning Free Wifi Breakfast", img = "PallasTarty.png", address = "Riia, 4"},
                }
            });
            listCities.Add(new City
            {
                id = 3,
                Title = "Toila",
                Hotels = new List<Hotel>()
                 {
                 new Hotel { id = 5, name = "Toila Spa Hotel", services = "Спа и оздоровительный центр Бассейн Бесплатная парковка ", img = "Toila.png", address = "Ranna, 12" }
                 }
            });

        }
    }
}