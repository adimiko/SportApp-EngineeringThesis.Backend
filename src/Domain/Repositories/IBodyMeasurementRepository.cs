using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBodyMeasurementRepository : IRepository
    {
        Task<BodyMeasurement> GetAsync(Guid id);
        Task<IEnumerable<BodyMeasurement>> BrowseAsync(Guid accountId, int page, int perPage);
        Task AddAsync(BodyMeasurement bodyMeasurement);  
        Task UpdateAsync(BodyMeasurement bodyMeasurement);
        Task DeleteAsync(BodyMeasurement bodyMeasurement);
    }
}