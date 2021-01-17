using Cw7.Models;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Cw7.Services
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string logFile = "log.json";
        public void Log(Log log)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(log, options);

            File.AppendAllText(logFile, jsonString, Encoding.UTF8);
        }
    }
}
