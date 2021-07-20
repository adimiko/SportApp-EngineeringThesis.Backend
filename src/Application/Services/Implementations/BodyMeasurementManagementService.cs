using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.BodyMeasurements;
using Application.Errors;
using Application.Exceptions;
using Application.Extensions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class BodyMeasurementManagementService : IBodyMeasurementManagementService
    {
        private readonly IBodyMeasurementRepository _bodyMeasurementRepository;
        private readonly IMapper _mapper;
        public BodyMeasurementManagementService(IBodyMeasurementRepository bodyMeasurementRepository, IMapper mapper)
        {
            _bodyMeasurementRepository = bodyMeasurementRepository;
            _mapper = mapper;
        }

        public async Task<BodyMeasurementDetailsDto> GetAsync(Guid id, Guid accountId)
        {
            var bodyMeasurement = await _bodyMeasurementRepository.GetOrFailureAsync(id);
            if(bodyMeasurement.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");

            return _mapper.Map<BodyMeasurementDetailsDto>(bodyMeasurement);
        }

        public async Task<IEnumerable<BodyMeasurementDto>> BrowseAsync(Guid accountId, int page, int perPage)
            => _mapper.Map<IEnumerable<BodyMeasurementDto>>(await _bodyMeasurementRepository.BrowseAsync(accountId, page, perPage));
        public async Task CreateAsync(Guid id, Guid accountId, string description, DateTime date, float weight, int height, float arm, float chest, float waist, float hip, float thigh, float calf)
        {
            var bodyMeasurement = await _bodyMeasurementRepository.GetAsync(id);

            if(bodyMeasurement != null)
            {
                throw new EntityAlreadyExistsException
                (
                   ServiceErrorCodes.BodyMeasurement.AlreadyExists,
                   $"Body measurement with id '{id}' already exists."
                );
            }

            try
            {
                bodyMeasurement = new BodyMeasurement(id, accountId, description, date, weight, height, arm, chest, waist, hip, thigh, calf);
            }
            catch(InvalidIdException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }
            catch(InvalidMeasurementValueException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            await _bodyMeasurementRepository.AddAsync(bodyMeasurement);
        }
        public async Task UpdateAsync(Guid id, Guid accountId, string description, DateTime date, float weight, int height, float arm, float chest, float waist, float hip, float thigh, float calf)
        {
            var bodyMeasurement = await _bodyMeasurementRepository.GetAsync(id);

            if(bodyMeasurement.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            try
            {
                bodyMeasurement.SetDate(date);
                bodyMeasurement.SetDescription(description);
                bodyMeasurement.SetWeight(weight);
                bodyMeasurement.SetHeight(height);
                bodyMeasurement.SetArm(arm);
                bodyMeasurement.SetChest(chest);
                bodyMeasurement.SetWaist(waist);
                bodyMeasurement.SetHip(hip);
                bodyMeasurement.SetThigh(thigh);
                bodyMeasurement.SetCalf(calf);
            }
            catch(InvalidMeasurementValueException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }

            await _bodyMeasurementRepository.UpdateAsync(bodyMeasurement);
        }
        public async Task DeleteAsync(Guid id, Guid accountId)
        {
            var bodyMeasurement = await _bodyMeasurementRepository.GetOrFailureAsync(id);
            if(bodyMeasurement.AccountId != accountId) throw new AccessDeniedException("You do not have access to this resource");
            await _bodyMeasurementRepository.DeleteAsync(bodyMeasurement);
        }
    }
}