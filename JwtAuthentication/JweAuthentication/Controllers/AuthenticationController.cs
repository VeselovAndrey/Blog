namespace JweAuthentication.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using JweAuthentication.Models;
    using JweAuthentication.Services.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [AllowAnonymous]
        public ActionResult<string> Post(
            AuthenticationRequest authRequest,
            [FromServices] IJwtSigningEncodingKey signingEncodingKey,
            [FromServices] IJwtEncryptingEncodingKey encryptingEncodingKey)
        {
            // 1. Проверяем данные пользователя из запроса.
            // ...

            // 2. Создаем утверждения для токена.
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, authRequest.Name)
            };

            // 3. Генерируем JWT.
            var tokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(
                issuer: "DemoApp",
                audience: "DemoAppClient",
                subject: new ClaimsIdentity(claims),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(5),
                issuedAt: DateTime.Now,
                signingCredentials: new SigningCredentials(
                    signingEncodingKey.GetKey(),
                    signingEncodingKey.SigningAlgorithm),
                encryptingCredentials: new EncryptingCredentials(
                    encryptingEncodingKey.GetKey(),
                    encryptingEncodingKey.SigningAlgorithm,
                    encryptingEncodingKey.EncryptingAlgorithm));

            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}