
namespace SalesAndFinance.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> LoginAsync(string email, string password);
    }
}
