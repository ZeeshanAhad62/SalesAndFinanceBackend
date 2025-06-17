using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> PostCategory(CategoryProduct cat)
        {
            await _dbContext.CategoryProducts.AddAsync(cat);
            await _dbContext.SaveChangesAsync();

            return "Success";
        }

        public async Task<List<CategoryProduct>> GetCategories()
        {
            return  await _dbContext.CategoryProducts.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<string> UpdateCategory(string catName, int id)
        {
            CategoryProduct cp = await _dbContext.CategoryProducts.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
            cp.CategoryName = catName;
            cp.ModifiedAt = DateTime.UtcNow;

            _dbContext.CategoryProducts.Update(cp);
            await _dbContext.SaveChangesAsync();

            return "Success";
        }

        public async Task<string> DeleteCategory(int catId)
        {
            CategoryProduct cp = _dbContext.CategoryProducts.Where(x => x.Id ==catId).FirstOrDefault();
            cp.IsDeleted = true;
            cp.ModifiedAt = DateTime.UtcNow;

            _dbContext.CategoryProducts.Update(cp);
            await _dbContext.SaveChangesAsync();

            return "Success";
        }

    }
}
