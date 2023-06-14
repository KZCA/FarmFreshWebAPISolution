using FarmFresh.Business.Services;
using FarmFresh.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace FarmFreshWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _productService.GetAllProducts();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var productDetails = await _productService.GetProductById(Id);

            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product productDetails)
        {
            var isProductCreated = await _productService.CreateProduct(productDetails);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product productDetails)
        {
            if (productDetails != null)
            {
                var isProductCreated = await _productService.UpdateProduct(productDetails);
                if (isProductCreated)
                {
                    return Ok(isProductCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var isProductCreated = await _productService.DeleteProduct(Id);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("pagination/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> PaginatedGetAllProduct(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0)
                return BadRequest();

            var data = await _productService.PaginatedProducts(pageIndex, pageSize);
            return Ok(new
            {
                data,
                data.PageIndex,
                data.TotalData,
                data.TotalPages
            });
        }

		[HttpGet("GetProductByCategoryId/{categoryid}/{page}/{pagesize}")]
		public async Task<IActionResult> GetProductByCategoryId(int categoryid, int page, int pagesize)
		{
			if (page < 0 || pagesize < 0)
				return BadRequest("Please enter pageIndex and pageSize");

			var data = await _productService.GetProductByCategoryId(categoryid, page, pagesize);

			if (data != null)
			{
				return Ok(new
				{
					data,
					data.PageIndex,
					data.TotalData,
					data.TotalPages
				});
			}
			else
			{
				return BadRequest();
			}
		}

        [HttpGet("GetAllProductByIncludeCategory/{page}/{pagesize}")]
        public async Task<IActionResult> GetAllProductByIncludeCategory(int page, int pagesize)
        {
            if (page < 0 || pagesize < 0)
                return BadRequest("Please enter pageIndex and pageSize");

            var data = await _productService.GetAllByIncude(page, pagesize);

            if (data != null)
            {
                return Ok(new
                {
                    data,
                    data.PageIndex,
                    data.TotalData,
                    data.TotalPages
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProductByslug/{slug}")]
        public async Task<IActionResult> GetProductByslug(string slug)
        {
            var productDetails = await _productService.GetProductBySlug(slug);

            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}

