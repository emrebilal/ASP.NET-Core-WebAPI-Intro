using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Intro.Model;

namespace WebAPI_Intro.Data
{
    public class DataService
    {
        public List<ProductModel> Products = new List<ProductModel>();

        public DataService()
        {
            FillData();
        }

        public void FillData()
        {
            string data = File.ReadAllText("data.json");
            List<ProductModel> tempProducts = JsonConvert.DeserializeObject<List<ProductModel>>(data);

            if (tempProducts != null)
            {
                foreach (var product in tempProducts)
                {
                    Products.Add(new ProductModel { Id = product.Id, ProductName = product.ProductName, ProductCategory = product.ProductCategory, Price = product.Price });
                }
            }
        }

        public void SaveJsonFile()
        {
            string newData = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText("data.json", newData);
        }
    }
}
