namespace JweAuthentication.Services.Authentication
{
    using Microsoft.IdentityModel.Tokens;

    // Ключ для шифрования данных (публичный)
    public interface IJwtEncryptingEncodingKey
    {
        string SigningAlgorithm { get; }

        string EncryptingAlgorithm { get; }

        SecurityKey GetKey();
    }
}