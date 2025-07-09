using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAndFinance.Application.Common;
using SalesAndFinance.Application.Services.Units.Dto;
using SalesAndFinance.Domain.Interfaces;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Application.Services.Units
{
    internal class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<ResponseResult<Unit>> PostUnit(UnitRequestDto requestDto, int loggedInUserID)
        {
            ResponseResult<Unit> response = new();
            try
            {
                Unit u = new Unit();
                u.UnitName = requestDto.UnitName;
                u.ShortName = requestDto.ShortName;
                u.CreatedAt = DateTime.UtcNow;
                u.CreatedBy = loggedInUserID;
                u.ModifiedBy = loggedInUserID;
                u.ModifiedAt = DateTime.UtcNow;
                u.IsDeleted = false;

                var request = await _unitRepository.PostUnit(u);

                response.Result = request;
                response.ResponseStatus = ResponseStatuses.Success;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatuses.InternalServerError;
                response.Error = ex.Message;
            }

            return response;
        }

        public async Task<ResponseResult<List<Unit>>> GetAllUnits()
        {
            ResponseResult<List<Unit>> response = new();
            try
            {
                var result = await _unitRepository.GetAllUnits();

                response.Result = result;
                response.ResponseStatus = ResponseStatuses.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.ResponseStatus = ResponseStatuses.InternalServerError;
            }
            return response;
        }

        public async Task<ResponseResult<string>> DeleteUnit(int id, int uId)
        {
            ResponseResult<string> response = new();
            try
            {
                var result = await _unitRepository.DeleteUnit(id, uId);

                response.Result = result;
                response.ResponseStatus = ResponseStatuses.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.ResponseStatus= ResponseStatuses.InternalServerError;
            }
            return response;
        }
    }
}
