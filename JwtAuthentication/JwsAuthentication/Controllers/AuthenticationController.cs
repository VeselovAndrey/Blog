namespace JwsAuthentication.Controllers
{
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using JwsAuthentication.Models;
	using JwsAuthentication.Services.Authentication;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;

	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController : ControllerBase
	{
		[AllowAnonymous]
		public ActionResult<string> Post(
			AuthenticationRequest authRequest,
			[FromServices] IJwtSigningEncodingKey signingEncodingKey)
		{
			// 1. Проверяем данные пользователя из запроса.
			// ...

			// 2. Создаем утверждения для токена.
			var claims = new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, authRequest.Name)
			};

			// 3. Генерируем JWT.
			var token = new JwtSecurityToken(
				issuer: "DemoApp",
				audience: "DemoAppClient",
				claims: claims,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: new SigningCredentials(
					signingEncodingKey.GetKey(),
					signingEncodingKey.SigningAlgorithm)
			);

			string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

			return jwtToken;
		}
	}
}