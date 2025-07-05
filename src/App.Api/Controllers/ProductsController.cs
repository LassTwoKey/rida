using Microsoft.AspNetCore.Mvc;
using App.Api.Contracts;
using App.Core.Abstractions;
using App.Core.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using App.Application.Services;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductsService _productsService;
        private readonly Cloudinary _cloudinary;

        public ProductsController(IConfiguration configuration, IProductsService productsService)
        {
            _configuration = configuration;
            _productsService = productsService;
            _cloudinary = new Cloudinary(_configuration.GetConnectionString("CloudinaryUrl") ?? "");
            _cloudinary.Api.Secure = true;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();
            var random = new Random();

            var productsResponse = products.Select(p => new ProductsResponse(
                p.Id,
                p.Title,
                p.Description,
                p.Discount,
                p.Rating,
                p.Price,
                DateTime.Now.AddDays(random.Next(7, 61)),
                p.Brand,
                p.IsFavorite,
                p.Categories,
                p.CreatedDate,
                p.ChangedDate,
                p.ImgUrl,
                p.ImgPreviewUrl,
                p.ImgId
                ));

            return Ok(productsResponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductsResponse>> GetProductById(Guid id)
        {
            var product = await _productsService.GetProductById(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            var random = new Random();

            return new ProductsResponse(
                product.Id,
                product.Title,
                product.Description,
                product.Discount,
                product.Rating,
                product.Price,
                DateTime.Now.AddDays(random.Next(7, 61)),
                product.Brand,
                product.IsFavorite,
                product.Categories,
                product.CreatedDate,
                product.ChangedDate,
                product.ImgUrl,
                product.ImgPreviewUrl,
                product.ImgId
                );
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromForm] ProductsRequest request)
        {
            string imageUrl = "";
            string imgPreviewFile = "";
            string? imgId = null;

            if (request.ImageFile != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(request.ImageFile.FileName, request.ImageFile.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = true,
                    Folder = "rida/products/"
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                imgId = uploadResult.PublicId;
                imageUrl = FileTransformationUrlService.GetTransformationUrl(
                    uploadResult.SecureUrl.ToString(),
                    ""
                );
                imgPreviewFile = FileTransformationUrlService.GetTransformationUrl(
                    uploadResult.SecureUrl.ToString(),
                    "c_thumb,h_200,w_200"
                );
            }

            var (product, error) = Product.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Discount,
                request.Rating,
                request.Price,
                request.Brand,
                request.IsFavorite,
                request.Categories,
                request.IsHidden,
                DateTime.UtcNow,
                DateTime.UtcNow,
                imageUrl,
                imgPreviewFile,
                imgId
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var productId = await _productsService.CreateProduct(product);

            return Ok(productId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id,[FromForm] ProductsRequest request)
        {
            var foundProduct = await _productsService.GetProductById(id);

            if (foundProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            string imageUrl = foundProduct.ImgUrl;
            string imgPreviewFile = foundProduct.ImgPreviewUrl;
            string? imgId = foundProduct.ImgId;

            if (request.ImageFile != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(request.ImageFile.FileName, request.ImageFile.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = true,
                    Folder = "rida/products/"
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                imgId = uploadResult.PublicId;
                imageUrl = FileTransformationUrlService.GetTransformationUrl(
                    uploadResult.SecureUrl.ToString(),
                    ""
                );
                imgPreviewFile = FileTransformationUrlService.GetTransformationUrl(
                    uploadResult.SecureUrl.ToString(),
                    "c_thumb,h_200,w_200"
                );

                if (foundProduct.ImgId != null)
                {
                    var deletionParams = new DeletionParams(foundProduct.ImgId);
                    var deletionResult = _cloudinary.Destroy(deletionParams);
                }
            }

            var productId = await _productsService.UpdateProduct(
                id,
                request.Title,
                request.Description,
                request.Discount,
                request.Rating,
                request.Price,
                request.Brand,
                request.IsFavorite,
                request.Categories,
                request.IsHidden,
                DateTime.UtcNow,
                imageUrl,
                imgPreviewFile,
                imgId
                );

            return Ok(productId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            var foundProduct = await _productsService.GetProductById(id);

            if (foundProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            if (!string.IsNullOrEmpty(foundProduct.ImgId))
            {
                var deletionParams = new DeletionParams(foundProduct.ImgId);

                var deletionResult = _cloudinary.Destroy(deletionParams);
            }

            var productId = await _productsService.DeleteProduct( id );

            return Ok(productId);
        }
    }
}
