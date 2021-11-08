using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace svietnamAPI.Helper
{
    public static class PasswordHelper
    {
        public static (byte[] Salt, string HashedPassword) GenerateUserPasswordInfo(string passwordInput, byte[] salt)
        {
            (byte[] Salt, string HashedPassword) userPasswordInfo;
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passwordInput,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            userPasswordInfo.Salt = salt;
            userPasswordInfo.HashedPassword = hashed;

            return userPasswordInfo;
        }

        public static (byte[] Salt, string HashedPassword) GenerateUserPasswordInfo(string passwordInput)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return GenerateUserPasswordInfo(passwordInput, salt);
        }

        public static bool ValidateUserPasswordInfo(string passwordInput, byte[] salt, string hashedPassword)
        {
            var userPasswordInfo = GenerateUserPasswordInfo(passwordInput, salt);

            var hashedPasswordClient = userPasswordInfo.HashedPassword;
            bool isVerified = String.Equals(hashedPassword, hashedPasswordClient);
            return isVerified;
        }
    }
}