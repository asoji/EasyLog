<h1 align="center">
  EasyLogPlus
</h1>
<p align="center">
  Simple and easy to use logging system originally created by 0x74. Extended by asoji.
  <br>
  <img src="https://user-images.githubusercontent.com/99072163/186797668-77e1dbeb-69a5-43bf-b9a3-b513468cc6d8.png">
</p>

## What's different between this and the original repo?
- Uses .NET 6 instead of .NET Framework 4.x
- The text is more way readable [in my opinion]*
- Customizable severity level colors
- Added the whole Syslog Severity Level standardization [[read about that here](https://en.wikipedia.org/wiki/Syslog#Severity_level)], cranking from 4 severity levels to 8.
- Uses your local timezone in logs instead of UTC timezone
- Switchable between `:` and `=>` in logs, like `NOTICE: This is notice text!` or `NOTICE => This is notice text!` using `cfg.UseColon`
- **Probably a lot of breaking changes**, but I plan on basically keeping this seperate from the original project.

Basically, I should've just made my own logger considering how much I changed, but eh, this fork works, and I'm pretty happy with it. 

*- This is what the original looked like on my screen in Rider and **oh no**.

![ohno](https://user-images.githubusercontent.com/99072163/186800223-deffa9b9-eea4-40bc-a148-5d3262abf8de.png)

It looks a lot better like this now

![ohyes](https://user-images.githubusercontent.com/99072163/186800405-88117e0d-6ce8-4504-97cd-b477f15cfd78.png)

## How to use?
- Install EasyLogPlus from GitHub's NuGet Registry, instructions [here](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#installing-a-package), make sure it's authors are `0x74, extended by asoji`
- Add `using EasyLogPlus;`
to top
Then add
```cs
Logger log = new Logger();
Config cfg = new Config();
```


## Customization Options
If you want customize settings add these, keeping in mind that this whole `SetConfig()` is optional, and not required to run the application.
```cs
void SetConfig()
{
    cfg.LogPath = Environment.CurrentDirectory + @"\Application.log"; // Set path where you want log to be saved
    cfg.ShowDate = true; // If this is set to true it will add date to the log
    cfg.Console = true; // If this is set to true it will print the log to Console too

    // ENTIRELY optional, just add and change if you want.
    cfg.UseColon = true; // If set to true, uses `:` in logs instead of `=>`

    cfg.DebugForeground = ConsoleColor.Blue;
    cfg.InfoForeground = ConsoleColor.Gray;
    cfg.NoticeForeground = ConsoleColor.Green;
    cfg.WarningForeground = ConsoleColor.DarkYellow;
    cfg.ErrorForeground = ConsoleColor.Red;

    cfg.CriticalBackground = ConsoleColor.DarkRed;
    cfg.AlertBackground = ConsoleColor.DarkBlue;
    cfg.EmergencyBackground = ConsoleColor.DarkMagenta;
}
```
Then in your application main void add these, **this is required**.
```cs
log.cfg = cfg;
SetConfig();
log.InitLogger(); // Call this to init logger
```

## Using Logs
- Debug Log
```cs
log.Debug("Hello from log, this is debug");
```

- Info Log
```cs
log.Info("Hello from log, this is info");
```

- Notice Log
```cs
log.Notice("Hello from log, this is notice");
```

- Warning Log
```cs
log.Warning("Hello from log, this is warning");
```

- Error Log
```cs
log.Error("Hello from log, this is error");
```

- Critical Log
```cs
log.Critical("Hello from log, this is critical")
```

- Alert Log
```cs
log.Alert("Hello from log, this is alert")
```

- Emergency Log
```cs
log.Emergency("Hello from log, this is emergency")
```

## [terrible] Example

```cs
class Program {
        static Logger log = new Logger();
        static Config cfg = new Config();
        
        static void SetConfig() {
            cfg.LogPath = Environment.CurrentDirectory + @"\Application.log";
            cfg.ShowDate = true;
            cfg.Console = true;

            cfg.UseColon = false;

            cfg.CriticalBackground = ConsoleColor.Cyan;
        }

        static void Main(string[] args) {
            SetConfig();
            log.cfg = cfg;
            log.InitLogger();

            try {
                // do some random shit
            } catch (ArgumentOutOfRangeException outOfRangeException) {
                log.Error("hey something is out of range?");
            }
            
            Console.ReadKey();
        }
    }
```

## License

This project [well, fork] is [MIT Licensed](LICENSE). Thank you byte-0x74/0x74 for making the original lib C:
