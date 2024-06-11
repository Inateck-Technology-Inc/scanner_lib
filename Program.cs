namespace csharp_sdk;
using InateckScannerBle;

class Program
{
    static void Main(string[] args)
    {
        ScannerBle scanner = new ScannerBle();
        string sdkVersion = scanner.SdkVersion();
        Console.WriteLine("SDK Version: " + sdkVersion);
        int status = scanner.RegisterEvent((message) =>
        {
            Console.WriteLine("Message: " + message);
        });
        if (status != 0)
        {
            Console.WriteLine("Init failed: " + status);
            Environment.Exit(1);
        }
        Console.WriteLine("init success Status: " + status);
        while (true)
        {
            string? input = Console.ReadLine();
            input = input?.Trim();
            if (input == null)
            {
                continue;
            }
            string[] cmd = input.Split(' ');
            string start = cmd[0];
            if (start != ">")
            {
                Console.WriteLine("Invalid command, example: > scan");
                continue;
            }
            if (cmd.Length < 2)
            {
                Console.WriteLine("Invalid command, example: > scan");
                continue;
            }
            string method = cmd[1];
            Console.WriteLine("method: " + method);
            if (method == "scan")
            {
                int scanResult = scanner.StartScan();
                Console.WriteLine("Scan Result: " + scanResult);
            }
            else if (method == "stop")
            {
                int stopResult = scanner.StopScan();
                Console.WriteLine("Stop Result: " + stopResult);
            }
            else if (method == "devices")
            {
                string devices = scanner.GetDevices();
                Console.WriteLine("Devices: " + devices);
            }
            else if (method == "connect")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > connect fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string device = scanner.Connect(mac, (message) =>
                {
                    Console.WriteLine("Code: " + message);
                });
                scanner.Auth(mac);
                Console.WriteLine("Device: " + device);
            }
            else if (method == "disconnect")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > disconnect fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                int device = scanner.Disconnect(mac);
                Console.WriteLine("Device: " + device);
            }
            else if (method == "version")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > version fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string version = scanner.GetHardwareVersion(mac);
                Console.WriteLine("Version: " + version);
            }
            else if (method == "battery")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > battery fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string battery = scanner.GetBattery(mac);
                Console.WriteLine("Battery: " + battery);
            }
            else if (method == "software")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > software fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string software = scanner.GetSoftwareVersion(mac);
                Console.WriteLine("Software: " + software);
            }
            else if (method == "settingInfo")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > settingInfo fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string settingInfo = scanner.GetSettingInfo(mac);
                Console.WriteLine("SettingInfo: " + settingInfo);
            }
            else if (method == "closeVolume")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > closeVolume fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string closeVolume = "[{\"area\":\"3\",\"value\":\"0\",\"name\":\"volume\"}]";
                string info = scanner.SetSettingInfo(mac, closeVolume);
                Console.WriteLine("SettingInfo: " + info);
            }
            else if (method == "openVolume")
            {
                if (cmd.Length < 3)
                {
                    Console.WriteLine("Invalid command, example: > closeVolume fb556f1d-f919-2d4d-c98c-fcbe246af2e4");
                    continue;
                }
                string mac = cmd[2];
                string closeVolume = "[{\"area\":\"3\",\"value\":\"4\",\"name\":\"volume\"}]";
                string info = scanner.SetSettingInfo(mac, closeVolume);
                Console.WriteLine("SettingInfo: " + info);
            }
            else if (method == "destroy")
            {
                scanner.Destroy();
            }
            else
            {
                Console.WriteLine("Invalid command, example: > scan");
            }
        }
    }
}
