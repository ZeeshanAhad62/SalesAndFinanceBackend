
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Units.Dto;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Application.Services.Units
{
    public interface IUnitService
    {
        Task<ResponseResult<Unit>> PostUnit(UnitRequestDto requestDto, int loggedInUserID);
    }
}
