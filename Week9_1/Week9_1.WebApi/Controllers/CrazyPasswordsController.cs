using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Week9_1.Shared.Helpers;
using Week9_1.Shared.Services;
using Week9_1.Shared.Utilities;

namespace Week9_1.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CrazyPasswordsController : ControllerBase
	{
		private readonly IIPService _ipService;

        private readonly ITextService _textService;

        private readonly IStringLocalizer<CommonTranslations> _localizer;

		private readonly PasswordGenerator _passwordGenerator;
		private readonly RequestCountService _requestCountService;

        public CrazyPasswordsController(PasswordGenerator passwordGenerator, RequestCountService requestCountService, IStringLocalizer<CommonTranslations> localizer, ITextService textService, IIPService ipService)
        {
            _passwordGenerator = passwordGenerator;
            _requestCountService = requestCountService;
            _localizer = localizer;
            _textService = textService;
            _ipService = ipService;
        }

        [HttpGet]
		public IActionResult Get()
		{
			_requestCountService.Count += 1;

			_ipService.Ip = "192.168.1.30"; 

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
