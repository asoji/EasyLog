using System;
using System.IO;
using EasyLog;

namespace Example {
    class Program {
        static Logger log = new Logger();
        static Config cfg = new Config();

        //If you want change logger settings create function like this and call it when application starts
        static void SetConfig() {
            cfg.LogPath = Environment.CurrentDirectory + @"\Application.log"; //Set path where you want log to be saved
            cfg.ShowDate = true; //If this is set to true it will add date to the log
            cfg.Console = true; //If this is set to true it will print the log to Console too
        }

        static void Main(string[] args) {
            SetConfig();
            log.cfg = cfg;
            log.InitLogger(); //Call this to init logger
            log.Info("This is info text!");
            log.Debug("This is debug text!");
            log.Warning("This is warning text!");
            log.Error("This is error text!");
            log.Critical("This is critical text!");
            log.Info("Press any key to stop this example!");
            Console.ReadKey();
        }
    }
}