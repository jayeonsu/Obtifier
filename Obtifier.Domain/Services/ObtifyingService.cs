using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Obtifier.Domain.Models;
using Obtifier.Domain.Repositories;
using Obtifier.Domain.ThreadFetcher;
using Obtifier.Domain.ThreadNotifier;



namespace Obtifier.Domain.Services
{
	public class ObtifyingService : IObtifyingService
	{
		private IThreadRepository ThreadRepository { get; }
		private IThreadFetcher ThreadFetcher { get; }
		private IThreadNotifier ThreadNotifier { get; }



		public ObtifyingService(IThreadRepository threadRepository, IThreadFetcher threadFetcher, IThreadNotifier threadNotifier)
		{
			ThreadRepository = threadRepository;
			ThreadFetcher = threadFetcher;
			ThreadNotifier = threadNotifier;
		}



		public async Task ObtifyAsync()
		{
			var fetchedThreads = await ThreadFetcher.Fetch();

			var newThreads = SelectNewlyUpdatedThreads(fetchedThreads);

			ThreadNotifier.Notify(newThreads);
		}



		private List<Thread> SelectNewlyUpdatedThreads(List<Thread> fetchedThreads)
		{
			var threadsInRepository = ThreadRepository.GetAll();

			var newThreads = fetchedThreads.Except(threadsInRepository, new ThreadEqualityComparer())
										   .Reverse()
										   .ToList();

			ThreadRepository.Add(newThreads);

			return newThreads;
		}
	}
}