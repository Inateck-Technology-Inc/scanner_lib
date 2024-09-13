namespace csharp_sdk;
using InateckScannerBle;
using Newtonsoft.Json.Linq;

class Program
{
    public const string CommandPrefix = "!";
    public static string MacAddress { get; set; }
    public static ScannerBle Scanner { get; set; }

    static Program()
    {
        MacAddress = "";
        Scanner = new ScannerBle();
    }

    static void Main(string[] args)
    {
        Scanner.Debug(true);
        string sdkVersion = Scanner.SdkVersion();
        Console.WriteLine("SDK Version: " + sdkVersion);
        Console.WriteLine("MacAddress: " + MacAddress ?? "N/A");
        int status = Scanner.RegisterEvent((message) =>
        {
            Console.WriteLine("Message: " + message);
            HandleEvents(message);
        });
        if (status != 0)
        {
            Console.WriteLine("Init failed: " + status);
            Environment.Exit(1);
        }
        Console.WriteLine("init success Status: " + status);
        while (true)
        {
            PrintMenu();
            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine();
            input = input?.Trim();
            if (input == null)
            {
                continue;
            }
            string[] cmd = input.Split(' ');
            string command = cmd[0];
            if (!command.StartsWith(CommandPrefix))
            {
                PrintInRed("Invalid command.");
                continue;
            }
            command = command[CommandPrefix.Length..];
            PrintInGreen("Command: " + command);

            if (command == "scan")
            {
                int scanResult = Scanner.StartScan();
                PrintInGreen("Scan Result: " + scanResult);
            }
            else if (command == "stop")
            {
                int stopResult = Scanner.StopScan();
                PrintInGreen("Stop Result: " + stopResult);
            }
            else if (command == "devices")
            {
                string devices = Scanner.GetDevices();
                PrintInGreen("Devices: " + devices);
            }
            else if (command == "connect")
            {
                ConnectToScanner();
            }
            else if (command == "disconnect")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                int device = Scanner.Disconnect(MacAddress);
                PrintInGreen("Device: " + device);
            }
            else if (command == "setMac")
            {
                if (cmd.Length != 2)
                {
                    PrintInRed($"Invalid Format. Please use the command as follows: {CommandPrefix}setMac FF:FF:FF:FF:FF:FF");
                    continue;
                }
                MacAddress = cmd[1];
                PrintInGreen($"Set MacAddress to: {MacAddress}");
            }
            else if (command == "version")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string version = Scanner.GetHardwareVersion(MacAddress);
                PrintInGreen("Hardware version: " + version);
            }
            else if (command == "battery")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string battery = Scanner.GetBattery(MacAddress);
                PrintInGreen("Battery: " + battery);
            }
            else if (command == "software")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string software = Scanner.GetSoftwareVersion(MacAddress);
                PrintInGreen("Software: " + software);
            }
            else if (command == "settingInfo")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string settingInfo = Scanner.GetSettingInfo(MacAddress, DeviceType.ST21);
                PrintInGreen("SettingInfo: " + settingInfo.Replace("},", "},\n"));
            }
            else if (command == "quiet")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string closeVolume = "[{\"flag\":1001,\"value\":0}]";
                string info = Scanner.SetSettingInfo(MacAddress, closeVolume, DeviceType.ST21);
                Scanner.BeeOrShake(MacAddress);
                PrintInGreen("SettingInfo: " + info.Replace("},", "},\n"));
            }
            else if (command == "loud")
            {
                if (MacAddress == null)
                {
                    PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
                    continue;
                }
                string closeVolume = "[{\"flag\":1001,\"value\":4}]";
                string info = Scanner.SetSettingInfo(MacAddress, closeVolume, DeviceType.ST21);
                Scanner.BeeOrShake(MacAddress);
                PrintInGreen("SettingInfo: " + info.Replace("},", "},\n"));
            }
            else if (command == "destroy")
            {
                Scanner.Destroy();
            }
            else
            {
                PrintInRed($"Invalid command, example: {CommandPrefix} scan");
            }
            
        }
    }

    private static void ConnectToScanner()
    {
        if (MacAddress == null)
        {
            PrintInRed($"MacAddress is not assigned. Please use {CommandPrefix}setMac");
            return;
        }
        string device = Scanner.Connect(MacAddress, (message) =>
        {
            PrintInGreen("Mac: " + MacAddress);
            PrintInGreen("Code: " + message);

            JObject msgAsJson = JObject.Parse(message);
            var cleanedScannedCode = msgAsJson["code"]?.ToString();
            if (cleanedScannedCode != null)
            {
                PrintInGreen($"Cleaned scan result: {cleanedScannedCode}");
            }
            else
            {
                PrintInRed("Unable to extract code from json.");
            }
        });
        Scanner.Auth(MacAddress);
        PrintInGreen("Device: " + device);
    }

    private static void HandleEvents(string eventText)
    {
        JObject msgAsJson = JObject.Parse(eventText);
        var cleanedMessage = msgAsJson["msg"]?.ToString();
        if (cleanedMessage != null)
        {
            PrintInGreen($"Message: {cleanedMessage}");
            if (cleanedMessage == "scan") //scanner discovered
            {

            }
            else if (cleanedMessage == "disconnect")
            {
                
            }
            else
            {

            }
        }
    }

    private static void PrintMenu()
    {
        var preColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Command prefix: {CommandPrefix}");
        Console.WriteLine("Possible commands:\n" +
                          "\tscan --> scans for bluetooth devices\n" +
                          "\tstop --> stops scanning for bluetooth devices\n" +
                          "\tdevices --> shows discovered bluetooth devices\n" +
                          "\tdestroy --> destroys scanner property\n" +
                          "\tsetMac --> sets the mac address to the given one\n" +

                          "\n\tUse setMac before using the next commands:\n" +

                          "\t\tconnect --> connect to the device with the corresponding MacAddress\n" +
                          "\t\tdisconnect --> disconnect from the connected device\n" +
                          "\t\tversion --> print the hardware-version of the connected device\n" +
                          "\t\tbattery --> print the battery percentage of the connected device\n" +
                          "\t\tsoftware --> print the firmware version\n" +
                          "\t\tsettingInfo --> print all the settings\n" +
                          "\t\tquiet --> sets volume to 0\n" +
                          "\t\tloud --> sets volume to 4\n"
        //"\t\n" +
        );
        Console.ForegroundColor = preColor;
    }

    static void PrintInGreen(string printThis)
    {
        var consoleColorPre = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(printThis);
        Console.ForegroundColor = consoleColorPre;
    }
    static void PrintInRed(string printThis)
    {
        var consoleColorPre = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(printThis);
        Console.ForegroundColor = consoleColorPre;
    }
}
