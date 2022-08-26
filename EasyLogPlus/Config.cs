using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLogPlus {
    public class Config {
        public bool ShowDate = true;
        public bool Console = true;
        public bool UseColon = true;
        
        public string LogPath = Environment.CurrentDirectory + $@"\Application.log";

        public ConsoleColor DebugForeground = ConsoleColor.Blue;
        public ConsoleColor InfoForeground = ConsoleColor.Gray;
        public ConsoleColor NoticeForeground = ConsoleColor.Green;
        public ConsoleColor WarningForeground = ConsoleColor.DarkYellow;
        public ConsoleColor ErrorForeground = ConsoleColor.Red;

        public ConsoleColor CriticalBackground = ConsoleColor.DarkRed;
        public ConsoleColor AlertBackground = ConsoleColor.DarkBlue;
        public ConsoleColor EmergencyBackground = ConsoleColor.DarkMagenta;
    }
}