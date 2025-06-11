
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> LoginAsync(string email, string password);
    }
}
