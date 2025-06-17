using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Services.Category;
using SalesAndFinance.Application.Services.Category.Dto;
using SalesAndFinance.Application.Common;
using Azure.Core;
using SalesAndFinance.Domain.Common;
using Microsoft.AspNetCore.Authorization;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly CommonFunctions _commonFunctions;
        public CategoryController(ICategoryService categoryService, CommonFunctions commonFunctions)
        {
            _categoryService = categoryService;
            _commonFunctions = commonFunctions;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCategory(string catName)
        {
            int logedInUserId = _commonFunctions.getLoggedInUserId();
            if (logedInUserId == (int)RolesEnum.SuperAdmin || logedInUserId == (int)RolesEnum.Admin)
            {
                CategoryRequestDto request = new();
                request.CatName = catName;
                request.LogedInUserId = logedInUserId;
                var response = await _categoryService.PostCategory(request);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Only Admins Can add Category");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {

            var response = await _categoryService.GetCategory();

            if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCategory(string catName, int Id)
        {
            int logedInUserId = _commonFunctions.getLoggedInUserId();
            if (logedInUserId == (int)RolesEnum.SuperAdmin || logedInUserId == (int)RolesEnum.Admin)
            {
                var response = await _categoryService.UpdateCategory(catName, Id);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Only Admins Can add Category");
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            int logedInUserId = _commonFunctions.getLoggedInUserId();
            if (logedInUserId == (int)RolesEnum.SuperAdmin || logedInUserId == (int)RolesEnum.Admin)
            {
                var response = await _categoryService.DeleteCategory(id);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Only Admins Can add Category");
            }
        }
    }
}
