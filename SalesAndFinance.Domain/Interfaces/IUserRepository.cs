
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> SignUpAsync(User input);
    }
}
