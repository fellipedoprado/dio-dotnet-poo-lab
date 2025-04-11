using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Logger
    {
        private static readonly string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DIO.Series", "logs.txt");

        static Logger()
        {
            // Cria o diretório de logs se não existir
            string logDirectory = Path.GetDirectoryName(LogFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Cria o arquivo de log se não existir
            if (!File.Exists(LogFilePath))
            {
                using (var stream = File.Create(LogFilePath)) { }
            }
        }

        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }

        public static void Warning(string message)
        {
            WriteLog("WARNING", message);
        }

        public static void Error(string message, Exception ex = null)
        {
            WriteLog("ERROR", $"{message}{(ex != null ? $" | Exception: {ex.Message}" : "")}");
        }

        private static void WriteLog(string level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            try
            {
                // Grava a mensagem no arquivo de log
                using (StreamWriter writer = new StreamWriter(LogFilePath, append: true))
                {
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar log: {ex.Message}");
            }
        }
    }
}