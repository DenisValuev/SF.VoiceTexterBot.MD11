using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using SF.VoiceTexterBot.Module11.Controllers;
using SF.VoiceTexterBot.Module11.Services;
using SF.VoiceTexterBot.Module11.Configuration;

namespace SF.VoiceTexterBot.Module11
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            //Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))//Задаем конфигурацию
                .UseConsoleLifetime() //Позволяет поддерживать приложение активным в консоли
                .Build(); //Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettigs();
            services.AddSingleton(BuildAppSettigs());

            //Подключаем хранилище пользовательских данных в памяти
            services.AddSingleton<IStorage, MemoryStorage>();

            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            // Регистрируем объект TelegramBotClient с токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new 
            TelegramBotClient(appSettings.BotToken));

            services.AddSingleton<IFileHandler, AudioFileHandler>();

            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettigs()
        {
            return new AppSettings()
            {
                DownloadsFolder = "D:\\Downloads",
                BotToken = "7477165269:AAHJjwtxhEVc6ZNXxaxYcYsT8XU7u6Zkz3E",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav",
                InputAudioBitrate = 48000,
            };
        }
    }
}
