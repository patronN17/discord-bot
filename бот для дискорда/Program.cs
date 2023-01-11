using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace бот_для_дискорда
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsynk().GetAwaiter().GetResult();
        private async Task MainAsynk()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "token";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {
                    case "!привет":
                        {
                            msg.Channel.SendMessageAsync($"Здравствуйте, {msg.Author}");
                            break;
                        }
                    case "!рандом":
                        {
                            Random rnd = new Random();
                            msg.Channel.SendMessageAsync($"Ваше рандомное число: {rnd.Next(-2000, 2000)}");
                            break;
                        }
                }
            return Task.CompletedTask;
        }
    }
}
