using System.Collections.Generic;
using Obtifier.Domain.Models;



namespace Obtifier.Domain.ThreadNotifier
{
	public interface IThreadNotifier
	{
		void Notify(List<Thread> threads);
	}
}