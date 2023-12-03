using Microsoft.Extensions.Localization;
using Sotsera.Blazor.Toaster;

namespace Week9_1.BlazorDI.Services
{
	public class SotseraToastService : IToasterService
	{
		private readonly IToaster _toaster;
		

		public SotseraToastService(IToaster toaster)
		{
			_toaster = toaster;
		}

		void IToasterService.ShowInfo(string message)
		{
			_toaster.Info(message);
		}

		void IToasterService.ShowSuccess(string message)
		{
			_toaster.Success(message);
		}

		void IToasterService.ShowWarning(string message)
		{
			_toaster.Warning(message);
		}
	}
}
