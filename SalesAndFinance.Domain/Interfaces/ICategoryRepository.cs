using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<string> PostCategory(CategoryProduct cat);
    }
}
