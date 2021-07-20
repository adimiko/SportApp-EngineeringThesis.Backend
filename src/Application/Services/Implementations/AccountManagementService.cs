using System;
using System.Threading.Tasks;
using Application.DTOs.Accounts;
using Application.Errors;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        public AccountManagementService(IAccountRepository accountRepository, IEncrypter encrypter, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAsync(Guid accountId)
        {
            if(accountId == Guid.Empty)
            {
                throw new AccessDeniedException("Login to system.");
            }

            return _mapper.Map<AccountDto>(await _accountRepository.GetAsync(accountId));
        }


        public async Task<AccountDto> GetByEmailAsync(string email)
            => _mapper.Map<AccountDto>(await _accountRepository.GetByEmailAsync(email));

        public async Task ChangePasswordAsync(Guid accountId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            var account = await _accountRepository.GetAsync(accountId);
            if(account == null) 
            { 
                throw new AccessDeniedException("Login to system.");
            }

            if(account.Password !=_encrypter.GetHash(oldPassword, account.Salt))
            {
                throw new ServiceException
                (
                    ServiceErrorCodes.Account.InvalidOldPassword,
                    "Old password is incorrect."
                );
            }

            if(newPassword != confirmNewPassword)
            {
                throw new ServiceException
                (
                    ServiceErrorCodes.Account.InvalidConfirmPassword,
                    "Confirm password has to be the same as password."
                );
            }

            var salt = _encrypter.CreateSalt();
            var hash = _encrypter.GetHash(newPassword, salt);
            account.SetPassword(hash, salt);

            await _accountRepository.UpdateAsync(account);
        }

        public async Task DeleteAsync(Guid accountId)
        {
            var account = await _accountRepository.GetAsync(accountId);
            if(account == null)
            {
                throw new AccessDeniedException("Login to system.");
            }

            if(account.Role == Roles.Admin)
            {
                throw new AccessDeniedException("You are last administrator in the system.");
            }

            account.Delete();
            await _accountRepository.UpdateAsync(account);
        }

    }
}