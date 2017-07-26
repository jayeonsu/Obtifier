using System.Collections.Generic;



namespace Obtifier.Domain.Models
{
	class ThreadEqualityComparer : IEqualityComparer<Thread>
	{
		public bool Equals(Thread x, Thread y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode(Thread thread)
		{
			return thread.Id.GetHashCode();
		}
	}
}