namespace JweAuthentication.Services.Authentication
{
    using Microsoft.IdentityModel.Tokens;

    // Ключ для дешифрования данных (приватный)
    public interface IJwtEncryptingDecodingKey
    {
        SecurityKey GetKey();
    }
}