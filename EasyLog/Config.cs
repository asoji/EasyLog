using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLog
{
    public class Config
    {
        public bool ShowDate = true;
        public bool Console = true;
        public string LogPath = Environment.CurrentDirectory + @"\Application.log";
        public bool UseColon = true;
    }
}
