using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.VoiceTexterBot.Module11.Models;

namespace SF.VoiceTexterBot.Module11.Services
{
    public interface IStorage
    {
        /// <summary>
        /// Получение сесии пользователя по идентификатору
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        Session GetSession(long chatId);
    }
}
