using System.Collections.Generic;
using System.Threading.Tasks;
using Obtifier.Domain.Models;



namespace Obtifier.Domain.ThreadFetcher
{
	public interface IThreadFetcher
	{
		Task<List<Thread>> Fetch();
	}
}