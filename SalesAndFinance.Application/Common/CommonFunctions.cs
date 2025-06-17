using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SalesAndFinance.Domain.Common
{
    public class CommonFunctions
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonFunctions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int getLoggedInUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int.TryParse(userId, out int usrId);
            return usrId;
        }
    }
}
