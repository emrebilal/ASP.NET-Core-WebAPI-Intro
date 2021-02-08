using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Intro.Model;

namespace WebAPI_Intro.Data
{
    public class DataManager
    {
        private static readonly DataManager _instance;

        static DataManager()
        {
            _instance = new DataManager();
        }

        private DataManager()
        {
            FillData();
        }

        public static DataManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<ProductModel> Products = new List<ProductModel>();

        public void FillData()
        {
            string data = File.ReadAllText("sampledata.json");
            List<ProductModel> tempProducts = JsonConvert.DeserializeObject<List<ProductModel>>(data);

            if (tempProducts != null)
            {
                foreach (var product in tempProducts)
                {
                    Products.Add(new ProductModel { Id = product.Id, ProductName = product.ProductName, ProductCategory = product.ProductCategory, Price = product.Price });
                }
            }
        }

        public void SaveJsonData()
        {
            string newData = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText("sampledata.json", newData);
        }
    }
}
