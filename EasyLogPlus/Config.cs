using System;

namespace EasyLogPlus {
    public class Config {
        public bool ShowDate = true;
        public bool Console = true;
        public bool UseColon = true;
        
        public string LogPath = Environment.CurrentDirectory + $@"\Application.log";

        public ConsoleColor DebugText = ConsoleColor.Blue;
        public ConsoleColor InfoText = System.Console.ForegroundColor;
        public ConsoleColor NoticeText = ConsoleColor.Green;
        public ConsoleColor WarningText = ConsoleColor.DarkYellow;
        public ConsoleColor ErrorText = ConsoleColor.Red;
        public ConsoleColor CriticalText = ConsoleColor.White;
        public ConsoleColor AlertText = ConsoleColor.White;
        public ConsoleColor EmergencyText = ConsoleColor.White;

        public ConsoleColor DebugBackground = System.Console.BackgroundColor;
        public ConsoleColor InfoBackground = System.Console.BackgroundColor;
        public ConsoleColor NoticeBackground = System.Console.BackgroundColor;
        public ConsoleColor WarningBackground = System.Console.BackgroundColor;
        public ConsoleColor ErrorBackground = System.Console.BackgroundColor;
        public ConsoleColor CriticalBackground = ConsoleColor.DarkRed;
        public ConsoleColor AlertBackground = ConsoleColor.DarkBlue;
        public ConsoleColor EmergencyBackground = ConsoleColor.DarkMagenta;
    }
}