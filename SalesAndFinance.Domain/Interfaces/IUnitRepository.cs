using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface IUnitRepository
    {
        Task<Unit> PostUnit(Unit request);
    }
}
