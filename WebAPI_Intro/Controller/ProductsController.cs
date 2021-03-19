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
        private readonly DataService _dataService;
        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("/api/products")]
        public List<ProductModel> GetProducts()
        {
            return _dataService.Products;
        }

        [HttpGet("/api/products/{id}")]
        public ProductModel GetProduct(int id)
        {
            var data = _dataService.Products.FirstOrDefault(c => c.Id == id);

            return data;
        }

        [HttpPost("/api/products")]
        public ProductModel AddProduct([FromBody] ProductModel product)
        {
            _dataService.Products.Add(product);
            _dataService.SaveJsonFile();

            return product;
        }

        [HttpPut("/api/products/{id}")]
        public void UpdateProduct(int id, [FromBody] ProductModel product)
        {
            for (var index = _dataService.Products.Count - 1; index >= 0; index--)
            {
                if (_dataService.Products[index].Id == id)
                {
                    _dataService.Products[index] = product;
                }
            }
            _dataService.SaveJsonFile();
        }

        [HttpDelete("/api/products/{id}")]
        public void DeleteProduct(int id)
        {
            for (var index = _dataService.Products.Count - 1; index >= 0; index--)
            {
                if (_dataService.Products[index].Id == id)
                {
                    _dataService.Products.RemoveAt(index);
                }
            }
            _dataService.SaveJsonFile();
        }
    }
}
