using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week9_1.Shared.Utilities;

namespace Week9_1.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CrazyPasswordsController : ControllerBase
	{
		private readonly PasswordGenerator _passwordGenerator;
		private readonly RequestCountService _requestCountService;

		public CrazyPasswordsController(PasswordGenerator passwordGenerator, RequestCountService requestCountService)
		{
			_passwordGenerator = passwordGenerator;
			_requestCountService = requestCountService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			_requestCountService.Count += 1;

			return Ok(_passwordGenerator.Generate(10, true, true, true, true));
		}
		[HttpGet("GetCount")]
		public IActionResult GetCount() 
		{
			_requestCountService.Count += 1;

			return Ok(_passwordGenerator.GeneratedPasswordsCount);
		}

		[HttpGet("RequestCount")]
		public IActionResult GetRequestCount()
		{
			_requestCountService.Count += 1;

            return Ok(_requestCountService.Count);
		}


	}
}
