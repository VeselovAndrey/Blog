namespace JweAuthentication.Services.Authentication
{
    using Microsoft.IdentityModel.Tokens;

    // Ключ для проверки подписи (публичный)
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}