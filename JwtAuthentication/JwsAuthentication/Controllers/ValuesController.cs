namespace JwsAuthentication.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			var nameIdentifier = this.HttpContext.User.Claims
				.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			return new string[] { nameIdentifier?.Value, "value1", "value2" };
		}
	}
}