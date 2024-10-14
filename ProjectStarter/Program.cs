using Newtonsoft.Json;
using ProjectStarter.Entities.Address;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStarter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load COUNTRIES
            string filePathCountries = @"C:\Users\muham\Downloads\address\ulke.json";
            string countriesJson = File.ReadAllText(filePathCountries);
            List<Countries> countries = JsonConvert.DeserializeObject<List<Countries>>(countriesJson);

            // Load Cities
            string filePathCities = @"C:\Users\muham\Downloads\address\sehirler.json";
            string citiesJson = File.ReadAllText(filePathCities);
            List<Cities> cities = JsonConvert.DeserializeObject<List<Cities>>(citiesJson);

            // Load Districts
            string filePathDistricts = @"C:\Users\muham\Downloads\address\ilceler.json";
            string districtsJson = File.ReadAllText(filePathDistricts);
            List<Districts> districts = JsonConvert.DeserializeObject<List<Districts>>(districtsJson);

            // Load Neighborhoods from multiple files
            List<string> neighborhoodsFiles = new List<string>
        {
            @"C:\Users\muham\Downloads\address\mahalleler-1.json",
            @"C:\Users\muham\Downloads\address\mahalleler-2.json",
            @"C:\Users\muham\Downloads\address\mahalleler-3.json",  
            @"C:\Users\muham\Downloads\address\mahalleler-4.json"
        };

            List<Neighborhoods> allNeighborhoods = new List<Neighborhoods>();

            foreach (string filePath in neighborhoodsFiles)
            {
                if (File.Exists(filePath))
                {
                    string neighborhoodsJson = File.ReadAllText(filePath);
                    List<Neighborhoods> neighborhoodList = JsonConvert.DeserializeObject<List<Neighborhoods>>(neighborhoodsJson);
                    allNeighborhoods.AddRange(neighborhoodList);
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                }
            }

            // Insert into database
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.InsertCountries(countries);
            dbHandler.InsertCities(cities);
            dbHandler.InsertDistricts(districts);
            dbHandler.InsertNeighborhoods(allNeighborhoods);

            Console.WriteLine("Data inserted successfully.");
        }
    }
}
