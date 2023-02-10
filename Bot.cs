using System.Data;
using Telegram.Bot;

namespace TelegramTestBot
{
    class Bot
    {
        static ITelegramBotClient _botClient;
        static void Main(string[] args) 
        {
            _botClient = new TelegramBotClient("6296271965:AAH8wte44HJwbR4Bd6NoaNlaWDcSb9aSav4");

            var bot = _botClient.GetMeAsync().Result;

            Console.WriteLine($"El bot: {bot.Id} llamado {bot.FirstName} esta funcionando.");

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Igresa cualquier tecla para salir");
            Console.ReadKey();

            _botClient.StopReceiving();
        }
            private async static void _botClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e) 
            {
                if (e.Message.Text.ToLower().Contains("hola"))
                {
                    await _botClient.SendTextMessageAsync (
                        chatId: e.Message.Chat.Id,
                        text: $"Hola! Soy el bot personal de Tomás. ¿En que puedo servirle?"
                    );
                } 
                else if(e.Message.Text.ToLower().Contains($"sticker")) 
                {
                    await _botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "https://tlgrm.es/_/stickers/6a0/2ff/6a02ff87-514b-4f17-8ac1-2a9a7f73ebeb/1.jpg"
                    );
                } 
                else if(e.Message.Text.ToLower().Contains("contacto")) 
                {
                    await _botClient.SendContactAsync(
                        chatId: e.Message.Chat.Id,
                        phoneNumber: "+0318122023",
                        firstName: "Lionel",
                        lastName: "Messi"
                        );
                }
                else if(e.Message.Text.ToLower().Contains("adios")) 
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        text: $"Adios! Vuelve cuando quieras." 
                );
            }
        
            }
    }
}
