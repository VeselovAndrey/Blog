namespace JwsAuthentication.Services.Authentication
{
    using Microsoft.IdentityModel.Tokens;

    // Ключ для проверки подписи (публичный)
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}