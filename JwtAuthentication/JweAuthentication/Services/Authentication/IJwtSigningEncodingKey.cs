namespace JweAuthentication.Services.Authentication
{
    using Microsoft.IdentityModel.Tokens;

    // Ключ для создания подписи (приватный)
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }
}
