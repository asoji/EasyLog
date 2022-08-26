using System;
using System.IO;

namespace EasyLogPlus {
    public class Logger {
        public Config cfg;
        public bool isInit = false;

        public void InitLogger() {
            if (File.Exists(cfg.LogPath)) File.Delete(cfg.LogPath);
            else { var fs = File.Create(cfg.LogPath); fs.Close(); }

            isInit = true;
        }

        enum LogLevel { // trying to conform to the Syslog standard, found here
                        // https://en.wikipedia.org/wiki/Syslog#Severity_level
            Debug = 7,
            Info = 6,
            Notice = 5,
            Warning = 4,
            Error = 3,
            Critical = 2,
            Alert = 1,
            Emergency = 0
        }

        public string ProcessLogText(int level) {
            if (isInit == false) {
                return "Please Init logger first! you can init it by calling *YourLogName*.InitLogger();";
            }

            object text = string.Empty;

            switch (level) {
                case (int)LogLevel.Debug:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "DEBUG";
                    break;
                case (int)LogLevel.Info:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "INFO";
                    break;
                case (int)LogLevel.Notice:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "NOTICE";
                    break;
                case (int)LogLevel.Warning:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "WARNING";
                    break;
                case (int)LogLevel.Error:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "ERROR";
                    break;
                case (int)LogLevel.Critical:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "CRITICAL";
                    break;
                case (int)LogLevel.Alert:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "ALERT";
                    break;
                case (int)LogLevel.Emergency:
                    if (cfg.ShowDate) text += $"[{DateTime.Now.ToString()}] | ";
                    text += "EMERGENCY";
                    break;
            }

            switch (cfg.UseColon) {
                case (true):
                    text += ": ";
                    break;
                case (false):
                    text += " => ";
                    break;
            }

            return text.ToString();
        }

        public void Debug(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Debug) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = cfg.DebugForeground);
                Console.ForegroundColor = ConsoleColor.White;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Info(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Info) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = cfg.InfoForeground);
                Console.ForegroundColor = ConsoleColor.White;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }
        
        public void Notice(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Notice) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = cfg.NoticeForeground);
                Console.ForegroundColor = ConsoleColor.White;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Warning(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Warning) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = cfg.WarningForeground);
                Console.ForegroundColor = ConsoleColor.White;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Error(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Error) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = cfg.ErrorForeground);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }

        public void Critical(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Critical) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = ConsoleColor.White,
                    Console.BackgroundColor = cfg.CriticalBackground);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }
        
        public void Alert(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Alert) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = ConsoleColor.White,
                    Console.BackgroundColor = cfg.AlertBackground);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }
        
        public void Emergency(object Content) {
            string LogText = ProcessLogText((int)LogLevel.Emergency) + Content;
            if (cfg.Console) {
                Console.WriteLine(LogText, Console.ForegroundColor = ConsoleColor.White,
                    Console.BackgroundColor = cfg.EmergencyBackground);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            File.AppendAllText(cfg.LogPath, LogText + Environment.NewLine);
        }
    }
}