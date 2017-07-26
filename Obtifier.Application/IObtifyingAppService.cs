using System.Threading.Tasks;



namespace Obtifier.Application
{
	interface IObtifyingAppService
	{
		Task ObtifyForeverAsync();
		void Stop();
	}
}