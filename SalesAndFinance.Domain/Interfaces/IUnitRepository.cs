using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface IUnitRepository
    {
        Task<Unit> PostUnit(Unit request);
        Task<string> DeleteUnit(int id,int uId);
        Task<List<Unit>> GetAllUnits();
    }
}
