namespace Obtifier.Domain.Models
{
	public class Thread
	{
		public string Id => Link + Author + Text;
		public string Link { get; set; }
		public string Author { get; set; }
		public string Text { get; set; }
	}
}