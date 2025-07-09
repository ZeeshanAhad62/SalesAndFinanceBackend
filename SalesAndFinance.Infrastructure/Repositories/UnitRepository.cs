using Microsoft.EntityFrameworkCore;
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

        public async Task<string> DeleteUnit(int id, int uId)
        {
            var a = await _dbContext.Units.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
            a.IsDeleted = true;
            a.ModifiedBy = uId;
            a.ModifiedAt = DateTime.Now;

            _dbContext.Update(a);
            await _dbContext.SaveChangesAsync();
            
            return "Succes";   
        }

        public async Task<List<Unit>> GetAllUnits()
        {
            List<Unit> result = await _dbContext.Units.Where(x => x.IsDeleted == false).ToListAsync();

            return result;
        }

        public async Task<Unit> PostUnit(Unit request)
        {
            await _dbContext.Units.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }
    }
}
