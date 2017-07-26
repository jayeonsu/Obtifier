using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Obtifier.Domain.Models;
using Obtifier.Domain.ThreadFetcher;
using AngleSharp.Parser.Html;



namespace Obtifier.Infrastructure.ThreadFetchers
{
	public class OkkyCommunityThreadFetcher : IThreadFetcher
	{
		public async Task<List<Thread>> Fetch()
		{
			var httpClient = new HttpClient();
			var htmlParser = new HtmlParser();

			var okkyCommunityUrl = "https://okky.kr/articles/community";

			var httpResponse = await httpClient.GetAsync(okkyCommunityUrl);

			if (httpResponse.IsSuccessStatusCode)
			{
				var bodyString = await httpResponse.Content.ReadAsStringAsync();
				var dom = await htmlParser.ParseAsync(bodyString);

				var threadElements = dom.QuerySelectorAll(".list-group-item");

				var fetchedThreads = threadElements.Select(
					te => new Thread
					{
						Author = te.QuerySelector(".nickname").TextContent,
						Text = te.QuerySelector(".list-group-item-heading a").TextContent.Trim(),
						Link = "https://okky.kr" + te.QuerySelector(".list-group-item-heading a").GetAttribute("href")
					}).ToList();

				return fetchedThreads;
			}

			return new List<Thread>();
		}
	}
}