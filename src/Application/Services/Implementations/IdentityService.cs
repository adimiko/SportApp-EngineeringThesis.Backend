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
    public class IdentityService : IIdentityService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        public IdentityService(IAccountRepository accountRepository, IEncrypter encrypter, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _accountRepository.GetByEmailAsync(email);

            if(user == null) throw new ServiceException(ServiceErrorCodes.Account.InvalidCredentials,"Invalid credentials.");
            if(user.IsDeleted) throw new ServiceException(ServiceErrorCodes.Account.InvalidCredentials,"Invalid credentials.");
            var salt = user.Salt;
            var hash = _encrypter.GetHash(password, salt);
            if(user.Password != hash) throw new ServiceException(ServiceErrorCodes.Account.InvalidCredentials,"Invalid credentials.");
        }
        public async Task RegisterAsync(Guid id, string email, string name, string password, string confirmPassword, string role)
        {
            if(role == Roles.Admin)
            {
                var admin = await _accountRepository.GetAdminFirstOrDefaultAsync();
                if(admin != null) throw new EntityAlreadyExistsException(ServiceErrorCodes.Account.FirstAdminAlreadyExists, "First admin account already exists.");
            }
            var account = await _accountRepository.GetByEmailAsync(email);

            if(account != null) throw new EntityAlreadyExistsException(ServiceErrorCodes.Account.AlreadyExists, $"Account with email: {email} already exists.");

            account = await _accountRepository.GetByNameAsync(name);

            if(account != null ) throw new EntityAlreadyExistsException(ServiceErrorCodes.Account.AlreadyExists, $"Account with name: {name} already exists.");

            if(password.Length < 8 || password.Length > 50) throw new ServiceException(ServiceErrorCodes.Account.InvalidPasswordLength, $"The password must be between 8 and 50 characters.");
            if(password != confirmPassword) throw new ServiceException(ServiceErrorCodes.Account.InvalidConfirmPassword, "Confirm password has to be the same as password.");

            var salt = _encrypter.CreateSalt();
            password = _encrypter.GetHash(password, salt);

            try
            {
                account = new Account(id, email, name, password, salt, role);
            }
            catch(InvalidIdException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }
            catch(InvalidEmailException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidNameException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidPasswordException e)
            {
                throw new ServiceException(e.Code, e.Message);
            }
            catch(InvalidSaltException e)
            {
                throw new InternalException(e.Code, e.Message, e);
            }

            await _accountRepository.AddAsync(account);
        }
    }
}