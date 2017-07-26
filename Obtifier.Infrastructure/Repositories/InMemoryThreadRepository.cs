using System.Collections.Generic;
using Obtifier.Domain.Models;
using Obtifier.Domain.Repositories;



namespace Obtifier.Infrastructure.Repositories
{
	public class InMemoryThreadRepository : IThreadRepository
	{
		private static List<Thread> Threads { get; } = new List<Thread>();



		public List<Thread> GetAll()
		{
			return Threads;
		}



		public void Add(List<Thread> threads)
		{
			Threads.AddRange(threads);
		}
	}
}