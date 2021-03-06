﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Models;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    public class AdultService : IAdultService
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultService()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WritePersonsToFile();
            }
            else
            {
                var content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> tmp2 = new List<Adult>(adults);
            return tmp2;
        }

        public async Task<Adult> GetById(int id)
        {
            List<Adult> tmp2 = new List<Adult>(adults);
            foreach (var item in tmp2)
            {
                if (item.Id == id)
                {
                    Adult adult = item;
                    return adult;
                }
            }

            return null;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            var max = adults.Max(adult => adult.Id);
            adult.Id = ++max;
            adults.Add(adult);
            WritePersonsToFile();
        }
        
        public async Task EditAdultAsync(Adult adult)
        {
            adult.Update(adult);
            
        }

        private void adultsFile()
        {
            var productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productsAsJson);
        }
        public async Task RemoveAdultAsync(int Id)
        {
            var toRemove = adults.First(t => t.Id == Id);
            adults.Remove(toRemove);
            adultsFile();
        }
        private void Seed()
        {
            Adult[] ps =
            {
                new Adult

                {
                    JobTitle = "Ninja",
                    Id=  0,
                    FirstName= "Yeshua",
                    LastName= "Magana",
                    HairColor="Black",
                    EyeColor= "Blue",
                    Age= 44,
                    Weight= 61.4f,
                    Height= 166,
                    Sex= "M"
                },
                new Adult
                {
                    JobTitle = "Ninja",
                    Id = 1,
                    FirstName = "Jayden",
                    LastName = "Harrell",
                    HairColor = "Leverpostej",
                    EyeColor = "Brown",
                    Age = 43,
                    Weight = 76.6f,
                    Height = 145,
                    Sex = "F"
                }
            };
            adults = ps.ToList();
        }

        private void WritePersonsToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productsAsJson);
        }

        public async Task UpdateAdultAsync(Adult adultToUpdate)
        {
            foreach (var item in adults)
            {
                if (item.Id == adultToUpdate.Id)
                {
                    item.Update(adultToUpdate);
                }
            }
            adultsFile();
        }
    }

    
}
