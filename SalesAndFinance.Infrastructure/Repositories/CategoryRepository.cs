using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly SalesAndFinanceDbContext _dbContext;

        public CategoryRepository(SalesAndFinanceDbContext context)
        {
            _dbContext = context;
        }

        public Task<string> DeleteCategory(int catId)
        {
            CategoryProduct cp = _dbContext.CategoryProducts.Where(x => x.Id ==catId).FirstOrDefault();
            cp.IsDeleted = true;
            throw new NotImplementedException();
        }

        public Task<string> DiabledCategory(int catId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PostCategory(CategoryProduct cat)
        {
            await _dbContext.CategoryProducts.AddAsync(cat);
            await _dbContext.SaveChangesAsync();

            return "Success";
        }

        public Task<string> UpdateCategory(CategoryProduct catUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
