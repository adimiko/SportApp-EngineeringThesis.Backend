using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.BodyMeasurements;

namespace Application.Services.Interfaces
{
    public interface IBodyMeasurementManagementService : IService
    {
        Task<BodyMeasurementDetailsDto> GetAsync(Guid id,  Guid accountId);
        Task<IEnumerable<BodyMeasurementDto>> BrowseAsync(Guid accountId, int page, int perPage);
        Task CreateAsync(Guid id, Guid accountId, string description, DateTime date,float weight, int height, float arm,float chest,
                        float waist, float hip, float thigh, float calf);

        Task UpdateAsync(Guid id, Guid accountId, string description, DateTime date,float weight, int height, float arm,float chest,
                        float waist, float hip, float thigh, float calf);
        Task DeleteAsync(Guid id, Guid accountId);
    }
}