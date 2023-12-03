namespace Week9_1.BlazorDI.Services
{
	public class BlazoredToastService : IToasterService
	{
		private readonly IToasterService _toastService;

		public BlazoredToastService(IToasterService toastService)
		{
			_toastService = toastService;
		}
		void IToasterService.ShowInfo(string message)
		{
			_toastService.ShowInfo(message);
		}

		void IToasterService.ShowSuccess(string message)
		{
			_toastService.ShowSuccess(message);
		}

		void IToasterService.ShowWarning(string message)
		{
			_toastService.ShowWarning(message);
		}
	}
}
