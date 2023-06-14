using FarmFresh.DataAccess.Repository;
using FarmFresh.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FarmFresh.Business.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmFreshWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var objlst = await _categoryService.GetAllCategory();
            if (objlst == null)
            {
                return NotFound();
            }
            return Ok(objlst);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetCategoryById(string slug)
        {
            var obj = await _categoryService.GetCategoryBySlug(slug);

            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category model)
        {
            var isCreated = await _categoryService.CreateCategory(model);

            if (isCreated)
            {
                return Ok(isCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category model)
        {
            if (model != null)
            {
                var isUpdated = await _categoryService.UpdateCategory(model);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var isDeleted= await _categoryService.DeleteCategory(Id);

            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
