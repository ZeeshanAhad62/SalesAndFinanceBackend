using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Units;
using SalesAndFinance.Application.Services.Units.Dto;
using SalesAndFinance.Application.Services.Users;
using SalesAndFinance.Domain.Common;

namespace SalesAndFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly CommonFunctions _commonFunctions;
        public UnitController(IUnitService unitService, CommonFunctions commonFunctions)
        {
            _unitService = unitService;
            _commonFunctions = commonFunctions;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUnits(UnitRequestDto request)
        {
            int loggedInUserId = _commonFunctions.getLoggedInUserId();
            if (loggedInUserId == (int)RolesEnum.SuperAdmin || loggedInUserId == (int)RolesEnum.Admin)
            {
                var response = await _unitService.PostUnit(request, loggedInUserId);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Only Admins Can add Units");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUnits(int unitId)
        {
            var response = await _unitService.GetAllUnits();

            if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUnits(int unitId)
        {
            int loggedInUserId = _commonFunctions.getLoggedInUserId();
            if (loggedInUserId == (int)RolesEnum.SuperAdmin || loggedInUserId == (int)RolesEnum.Admin)
            {
                var response = await _unitService.DeleteUnit(unitId, loggedInUserId);

                if (response.ResponseStatus == ResponseStatuses.InternalServerError)
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Error);

                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Only Admins Can Delete Units");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("HelloWorld")]
        public IActionResult HelloWorld()
        {
            string a = "ok";
            return Ok(new { a});
        }
    }
}
