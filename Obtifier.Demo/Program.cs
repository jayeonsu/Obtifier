using System;
using Obtifier.Application;
using Obtifier.Domain.Services;
using Obtifier.Infrastructure.Repositories;
using Obtifier.Infrastructure.ThreadFetchers;
using Obtifier.Infrastructure.ThreadNotifiers;



namespace Obtifier.Demo
{
	class Program
	{
		static void Main()
		{
			var threadRepo = new InMemoryThreadRepository();

			var okkyFetcher = new OkkyCommunityThreadFetcher();

			var slackNotifier = new SlackThreadNotifier(
					webhookUrl: "https://hooks.slack.com/services/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",
					iconUrl: "http://okky.kr/assets/okky_logo_fb-cea175ff727ef14a4d8be0e68cff730a.png",
					channel: "#obtifier");

			var obtifyingService = new ObtifyingService(threadRepo, okkyFetcher, slackNotifier);


			var obtifyingAppService = new ObtifyingAppService(obtifyingService);
			obtifyingAppService.ObtifyForeverAsync();


			Console.WriteLine("Okky 커뮤니티 카테고리에서 새로운 글이 올라오는지 관찰 중... 발견 시, 슬랙에 통지!");
			Console.ReadLine();
		}
	}
}