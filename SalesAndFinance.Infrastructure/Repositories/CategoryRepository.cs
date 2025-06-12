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

        public async Task<string> PostCategory(CategoryProduct cat)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> PostCategory(CategoryProduct cat)
        //{
        //    return "success";
        //}
    }
}
