using Microsoft.EntityFrameworkCore;
using SalesAndFinance.Domain;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance.Infrastructure.Repositories
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly SalesAndFinanceDbContext _dbContext;
        public AuthRepository(SalesAndFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> LoginAsync(string email)
        {
            return await _dbContext.Users.Where(x => x.Email == email && x.IsDeleted == false && x.IsActive == 1).FirstOrDefaultAsync();

        }
    }
}
