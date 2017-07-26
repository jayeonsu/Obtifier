using System;
using System.Threading;
using System.Threading.Tasks;
using Obtifier.Domain.Services;



namespace Obtifier.Application
{
	public class ObtifyingAppService : IObtifyingAppService
	{
		private CancellationTokenSource CancellationTokenSource { get; set; }
		public TimeSpan ObtifyingCycle { get; set; } = TimeSpan.FromSeconds(15);
		public event Action Cancelled;

		private IObtifyingService ObtifyingService { get; }



		public ObtifyingAppService(IObtifyingService obtifyingService)
		{
			ObtifyingService = obtifyingService;
		}



		public async Task ObtifyForeverAsync()
		{
			CancellationTokenSource = new CancellationTokenSource();

			while (true)
			{
				if (CancellationTokenSource.IsCancellationRequested) break;
				await Task.Delay(ObtifyingCycle);

				await ObtifyingService.ObtifyAsync();
			}

			CancellationTokenSource.Dispose();
			Cancelled?.Invoke();
		}



		public void Stop()
		{
			CancellationTokenSource.Cancel();
		}
	}
}