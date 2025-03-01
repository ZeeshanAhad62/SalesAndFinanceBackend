using Microsoft.EntityFrameworkCore;
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

        public async Task<string> LoginAsync(string email, string password)
        {
            var response = await _dbContext.Users.Where(x => x.Email == email && x.PasswordHash == password && x.IsDeleted == false).Select(x => x.FirstName + x.LastName).FirstOrDefaultAsync();

            return response;
        }
    }
}
