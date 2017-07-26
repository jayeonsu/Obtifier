using System;
using System.Collections.Generic;
using Obtifier.Domain.Models;
using Obtifier.Domain.ThreadNotifier;
using Slack.Webhooks;



namespace Obtifier.Infrastructure.ThreadNotifiers
{
	public class SlackThreadNotifier : IThreadNotifier
	{
		private string WebhookUrl { get; }
		private Uri IconUrl { get; }
		private string Channel { get; }



		public SlackThreadNotifier(string webhookUrl, string iconUrl, string channel)
		{
			WebhookUrl = webhookUrl;
			IconUrl = new Uri(iconUrl);
			Channel = channel;
		}



		public void Notify(List<Thread> threads)
		{
			var slackClient = new SlackClient(WebhookUrl);

			foreach (var thread in threads)
			{
				var message = new SlackMessage
				{
					IconUrl = IconUrl,
					Channel = Channel,
					Username = thread.Author,
					Text = $"<{thread.Link}|{thread.Text}>"
				};

				slackClient.Post(message);
			}
		}
	}
}