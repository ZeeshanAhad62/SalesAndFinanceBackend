using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Category;
using SalesAndFinance.Application.Services.Category.Dto;
using SalesAndFinance.Application.Common;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryRequestDto request)
        {
            if (request.LogedInUserRole == (int)RolesEnum.SuperAdmin || request.LogedInUserRole == (int)RolesEnum.Admin)
            {
                var response = await _categoryService.PostCategory(request);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized,"Only Admins Can add Category");
            }
        }
    }
}
