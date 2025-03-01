using SalesAndFinance.Domain;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly SalesAndFinanceDbContext _dbContext;
        public UserRepository(SalesAndFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> SignUpAsync(User input)
        {
            await _dbContext.Users.AddAsync(input);
            await _dbContext.SaveChangesAsync();

            return input;
        }
    }
}
