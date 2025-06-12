
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Category.Dto;

namespace SalesAndFinance.Application.Services.Category
{
    public interface ICategoryService
    {
        Task<ResponseResult<string>> PostCategory(CategoryRequestDto request);
    }
}
