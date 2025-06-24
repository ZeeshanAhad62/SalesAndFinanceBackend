
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Category.Dto;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Application.Services.Category
{
    public interface ICategoryService
    {
        Task<ResponseResult<string>> PostCategory(CategoryRequestDto request);
        Task<ResponseResult<List<CategoryProduct>>> GetCategory();
        Task<ResponseResult<string>> UpdateCategory(string catName, int id);
        Task<ResponseResult<CategoryProduct>> DeleteCategory(int catId);
    }
}
