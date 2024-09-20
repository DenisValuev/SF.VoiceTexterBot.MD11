using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.VoiceTexterBot.Module11.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// Токен Telegram API
        /// </summary>
        public string BotToken { get; set; }

        /// <summary>
        /// Папка загрузки аудио файлов
        /// </summary>
        public string DownloadsFolder { get; set; }

        /// <summary>
        /// Имя файла при загрузке
        /// </summary>
        public string AudioFileName { get; set; }
        
        /// <summary>
        /// Формат аудио при загрузке
        /// </summary>
        public string InputAudioFormat { get; set; }

        /// <summary>
        /// Формат аудио конвертации
        /// </summary>
        public string OutputAudioFormat { get; set; }

        /// <summary>
        /// Битрейт аудио
        /// </summary>
        public float InputAudioBitrate { get; set; }
    }
}
