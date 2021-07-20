using System;
using System.Security.Cryptography;
using Application.Services.Interfaces;
using NETCore.Encrypt.Extensions;

namespace Application.Services.Implementations
{
    public class Encrytper : IEncrypter
    {
        private static readonly int SaltSize = 47;
        public string CreateSalt()
        {
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
            => value.HMACSHA256(salt);
    }
}