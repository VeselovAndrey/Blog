namespace RefreshTokenAuthentication.Services
{
    using System;
    using System.Security.Cryptography;

    // Сервис для создания случайной последовательности символов.
    public interface IRandomStringGenerator
    {
        string Generate();
    }

    public class RandomStringGenerator : IRandomStringGenerator
    {
        public string Generate()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
