using Microsoft.AspNetCore.Mvc;
using ApiImpl.Interfaces;
using ApiImpl.Models;
using ApiImpl.Services;
using System.ComponentModel.DataAnnotations;

namespace ApiImpl.Controllers
{



    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _prodServ;
        private readonly DtoValidationService _dtoValidation;

        public ProductsController(IProductsService prodServ, DtoValidationService dtoValidation)
        {
            _prodServ = prodServ;
            _dtoValidation = dtoValidation;
        }

        [HttpPost("create")]
        public async Task<Product> postProductAsync([FromBody] ProductDto productDto)
        {

            List<ValidationResult> errors;
            bool isValid = _dtoValidation.TryValidateDto(productDto, out errors);

            if (!isValid)
            {
                return null;
            }

            Product product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = productDto.Name,
                Description = productDto.Description,
                Stock = productDto.Stock

            };

            var result = await _prodServ.PostProductAsync(product);

            return result;

        }


        [HttpGet("all")]
        public async Task<List<Product>> getAllProductsAsync()
        {
            //get from services all products
            var result = await _prodServ.getAllProductsAsync();

            if (result == null || !result.Any()) return null;

            return result;
        }

        [HttpGet("id/{id}")]
        public async Task<Product> getByIdAsync(string id)
        {
            var result = await _prodServ.getByIdAsync(id);

            if (result == null) return null;

            return result;

        }


        [HttpPut("update/{id}")]
        public async Task<Product> updateByIdAsync(string id, [FromBody] ProductDto productDto)
        {

            List<ValidationResult> errors;
            bool isValid = _dtoValidation.TryValidateDto(productDto, out errors);

            if (!isValid)
            {
                return null;
            }

            Product? newProduct = new Product
            {
                Id = null,
                Name = productDto.Name,
                Description = productDto.Description,
                Stock = productDto.Stock
            };

            var result = await _prodServ.UpdateProductAsync(id, newProduct);

            return result;
        }

        [HttpDelete("delete/id/{id}")]
        public async Task<bool> deleteByIdAsync(string Id)
        {
            return await _prodServ.DeleteProductByIdAsync(Id);
        }

    }
}