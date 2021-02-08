using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Intro.Data;
using WebAPI_Intro.Model;

namespace WebAPI_Intro.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataManager dataManager;
        public ProductsController()
        {
            dataManager = DataManager.Instance;
        }

        [HttpGet("/api/products")]
        public List<ProductModel> GetProducts()
        {
            return dataManager.Products;
        }

        [HttpGet("/api/products/{id}")]
        public ProductModel GetProduct(int id)
        {
            var data = dataManager.Products.FirstOrDefault(c => c.Id == id);

            return data;
        }

        [HttpPost("/api/products")]
        public ProductModel AddProduct([FromBody] ProductModel product)
        {
            dataManager.Products.Add(product);
            dataManager.SaveJsonData();

            return product;
        }

        [HttpPut("/api/products/{id}")]
        public void UpdateProduct(int id, [FromBody] ProductModel product)
        {
            for (var index = dataManager.Products.Count - 1; index >= 0; index--)
            {
                if (dataManager.Products[index].Id == id)
                {
                    dataManager.Products[index] = product;
                }
            }
            dataManager.SaveJsonData();
        }

        [HttpDelete("/api/products/{id}")]
        public void DeleteProduct(int id)
        {
            for (var index = dataManager.Products.Count - 1; index >= 0; index--)
            {
                if (dataManager.Products[index].Id == id)
                {
                    dataManager.Products.RemoveAt(index);
                }
            }
            dataManager.SaveJsonData();
        }

    }
}
