using Microsoft.AspNetCore.Mvc;
using App.Api.Contracts;
using App.Core.Abstractions;
using App.Core.Models;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            var productsResponse = products.Select(p => new ProductsResponse(
                p.Id,
                p.Title,
                p.Description,
                p.OnSale,
                p.Rating,
                p.Price,
                p.EstimatedDeliveryDate,
                p.Brand,
                p.IsFavorite,
                p.Categories
                ));

            return Ok(productsResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] ProductsRequest request)
        {
            var (product, error) = Product.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.OnSale,
                request.Rating,
                request.Price,
                request.EstimatedDeliveryDate,
                request.Brand,
                request.IsFavorite,
                request.Categories,
                request.IsHidden
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var productId = await _productsService.CreateProduct(product);

            return Ok(productId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id,[FromBody] ProductsRequest request)
        {
            var productId = await _productsService.UpdateProduct(
                id,
                request.Title,
                request.Description,
                request.OnSale,
                request.Rating,
                request.Price,
                request.EstimatedDeliveryDate,
                request.Brand,
                request.IsFavorite,
                request.Categories,
                request.IsHidden
                );

            return Ok(productId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            var productId = await _productsService.DeleteProduct( id );

            return Ok(productId);
        }
    }
}
