using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Category.Dto;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndFinance.Application.Services.Category
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseResult<string>> PostCategory(CategoryRequestDto request)
        {
            ResponseResult<string> response = new();
            try
            {
                CategoryProduct cp = new CategoryProduct
                {
                    CategoryName = request.CatName,
                    TotalProducts = 0,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = request.LogedInUserId,
                    IsDeleted = false,
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = request.LogedInUserId,
                };

                var requestDb = await _categoryRepository.PostCategory(cp);

                response.Result = requestDb;
                response.ResponseStatus = ResponseStatuses.Success;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatuses.InternalServerError;
                response.Error = ex.Message;
            }
            return response;
        }
    }
}
