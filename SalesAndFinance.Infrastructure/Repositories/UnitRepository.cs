using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure.Data;

namespace SalesAndFinance.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly SalesAndFinanceDbContext _dbContext;
        public UnitRepository(SalesAndFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> PostUnit(Unit request)
        {
            await _dbContext.Units.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }
    }
}
