using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Week9_1.Shared.Helpers;
using Week9_1.Shared.Utilities;

namespace Week9_1.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PasswordsController : ControllerBase
	{
		private readonly IStringLocalizer<CommonTranslations> _localizer;


		private readonly PasswordGenerator _passwordGenerator;
		private readonly RequestCountService _requestCountService;
		public PasswordsController(PasswordGenerator passwordGenerator, RequestCountService requestCountService, IStringLocalizer<CommonTranslations> localizer)
		{
			_passwordGenerator = passwordGenerator;
			_requestCountService = requestCountService;
			_localizer = localizer;
		}

		[HttpGet]

		public IActionResult Get()
		{
			_requestCountService.Count += 1;

			return Ok(_passwordGenerator.Generate(10, true, true, true, true));
			 
		}

		[HttpGet("WelcomeMessage")]
		public IActionResult GetWelcomeMessage()
		{
			return Ok(_localizer["WelcomeMessage"]);
		}

		[HttpGet("GetCount")]
		public IActionResult GetCount()
		{
			_requestCountService.Count += 1;

			if(_passwordGenerator.GeneratedPasswordsCount == 0)
			{
				return BadRequest(_localizer["No passwords have been generated."]);
			}

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
