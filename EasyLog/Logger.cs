using System;
using System.IO;

namespace EasyLog
{
    public class Logger
    {
        public Config cfg;
        public bool isInit = false;

        public void InitLogger()
        {
            if (File.Exists(cfg.LogPath)) File.Delete(cfg.LogPath);
            else { var fs = File.Create(cfg.LogPath); fs.Close(); }
            isInit = true;
        }

        enum LogLevel
        {
            Info = 0,
            Debug,
            Warning,
            Error,
        }

        public string ProcessLogText(int level)
        {
            if (isInit == false)
            {
                return "Please Init logger first! you can init it by calling *YourLogName*.InitLogger();";
            }
            object text = string.Empty;
            switch (level)
            {
                case (int)LogLevel.Info:
                    if (cfg.ShowDate) text += $"[{DateTime.UtcNow.ToString()}] | ";
                    text += "INFO => ";
                    break;
                case (int)LogLevel.Debug:
                    if (cfg.ShowDate) text += $"[{DateTime.UtcNow.ToString()}] | ";
                    text += "DEBUG => ";
                    break;
                case (int)LogLevel.Warning:
                    if (cfg.ShowDate) text += $"[{DateTime.UtcNow.ToString()}] | ";
                    text += "WARNING => ";
                    break;
                case (int)LogLevel.Error:
                    if (cfg.ShowDate) text += $"[{DateTime.UtcNow.ToString()}] | ";
                    text += "ERROR => ";
                    break;
            }
            return text.ToString();
        }

        public void Debug(object Content)
        {
            string LogText = ProcessLogText((int)LogLevel.Debug) + Content;
            if (cfg.Console) { Console.WriteLine(LogText, Console.BackgroundColor = ConsoleColor.DarkYellow, Console.ForegroundColor = ConsoleColor.White); Console.BackgroundColor = ConsoleColor.White; }
            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Info(object Content)
        {
            string LogText = ProcessLogText((int)LogLevel.Info) + Content;
            if (cfg.Console) { Console.WriteLine(LogText, Console.BackgroundColor = ConsoleColor.Blue, Console.ForegroundColor = ConsoleColor.White); Console.BackgroundColor = ConsoleColor.White; }
            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Warning(object Content)
        {
            string LogText = ProcessLogText((int)LogLevel.Warning) + Content;
            if (cfg.Console) { Console.WriteLine(LogText, Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.White); Console.BackgroundColor = ConsoleColor.White; }
            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Error(object Content)
        {
            string LogText = ProcessLogText((int)LogLevel.Error) + Content;
            if (cfg.Console) { Console.WriteLine(LogText, Console.BackgroundColor = ConsoleColor.DarkRed, Console.ForegroundColor = ConsoleColor.White); Console.BackgroundColor = ConsoleColor.White; }
            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }
    }
}
