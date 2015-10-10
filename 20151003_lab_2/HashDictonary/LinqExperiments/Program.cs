using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HashDictonary;

namespace LinqExperiments
{
    public static class Program
    {
        private const int MIO = 1000000;
        
        private static IDictionary<string, int> GetCities()
        {
            return new HashDictonary<string, int>
            { 
                { "Hagenberg", 2500 }, 
                { "Linz", 190000 }, 
                { "Salzburg", 145000 }, 
                { "Wien", (int)(1.7*MIO) }, 
                { "Hamburg", (int)(1.7*MIO) }, 
                { "Berlin", (int)(3.4*MIO) }, 
                { "Tokio", 30*MIO },
                { "Seoul", 20*MIO }, 
                { "Mexiko-Stadt", 20*MIO }, 
                { "New York", 19*MIO }, 
                { "Kairo", 15*MIO }, 
                { "Madrid", 5*MIO }, 
                { "Mailand", 3*MIO }, 
                { "Las Vegas", 2*MIO }
            };
        }

        private static IDictionary<string, string> GetCountries()
        {
            return new HashDictonary<string, string> { 
                { "Hagenberg", "Österreich" }, 
                { "Linz", "Österreich" }, 
                { "Salzburg", "Österreich" }, 
                { "Wien", "Österreich" }, 
                { "Hamburg", "Deutschland" }, 
                { "Berlin", "Deutschland" }, 
                { "Tokio", "Japan" },
                { "Seoul", "Südkorea" }, 
                { "Mexiko-Stadt", "Mexiko" }, 
                { "New York", "USA" }, 
                { "Kairo", "Ägypten" }, 
                { "Madrid", "Spanien" }, 
                { "Mailand", "Italien" }, 
                { "Las Vegas", "USA" }
            };
        }

        public static void Main(string[] args)
        {
            var cities = GetCities();
            var countries = GetCountries();

            Console.WriteLine("Mega cities");
            Console.WriteLine("-----------");
            Console.WriteLine("No linq");
            Console.WriteLine("-----------");

            // no linq
            foreach (var item in GetCities())
            {
                if(item.Value > 10*MIO)
                {
                    Console.WriteLine(item.Key);
                }
            }

            // with linq
            Console.WriteLine("-----------");
            Console.WriteLine("With linq");
            Console.WriteLine("-----------");
            var megaCities = from city in cities where city.Value >= 10 * MIO select city.Key;
            foreach (var item in megaCities)
            {
                Console.WriteLine(item);
            }

            // with linq, largest 3
            Console.WriteLine("-----------");
            Console.WriteLine("With linq");
            Console.WriteLine("-----------");
            var largestThree = (from city in cities orderby city.Value descending select city).Take(3);
            foreach (var item in largestThree)
            {
                Console.WriteLine(item.ToString());
            }

            // with linq, joined with countries
            Console.WriteLine("-----------");
            Console.WriteLine("With linq");
            Console.WriteLine("-----------");
            var joinedCities = (from city in cities
                                join country in countries
                                on city.Key equals country.Key
                                select new {
                                    Name = city.Key,
                                    Inhabitants = city.Value,
                                    Country = country.Value
                                });

            foreach (var item in joinedCities)
            {
                Console.WriteLine(item.ToString());
            }

            // with linq, austria countries
            Console.WriteLine("-----------");
            Console.WriteLine("austrian cities");
            Console.WriteLine("-----------");
            var joinedCountryCities = (from country in countries
                                join city in cities
                                on country.Key equals city.Key
                                where country.Value == "Österreich"
                                orderby city.Value descending
                                select new
                                {
                                    Name = city.Key,
                                    Inhabitants = city.Value
                                });

            foreach (var item in joinedCountryCities)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
