
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<string> PostCategory(CategoryProduct cat);
        Task<List<CategoryProduct>> GetCategories();
        Task<string> UpdateCategory(string catName, int id);
        Task<string> DeleteCategory(int catId);
    }
}
