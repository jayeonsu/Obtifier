using System.Collections.Generic;
using Obtifier.Domain.Models;



namespace Obtifier.Domain.Repositories
{
	public interface IThreadRepository
	{
		List<Thread> GetAll();
		void Add(List<Thread> threads);
	}
}