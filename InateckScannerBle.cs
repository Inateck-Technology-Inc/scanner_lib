using System.Runtime.InteropServices;

namespace InateckScannerBle
{
    public delegate void Callback(string message);

    public class ScannerBle
    {
        public ScannerBle()
        {
            
        }

        public int RegisterEvent(Callback callback)
        {
            int status = ScannerBleC.inateck_scanner_ble_init(callback);
            return status;
        }

        public int Destroy()
        {
            return ScannerBleC.inateck_scanner_ble_destroy();
        }

        public int StartScan()
        {
            return ScannerBleC.inateck_scanner_ble_start_scan();
        }

        public int StopScan()
        {
            return ScannerBleC.inateck_scanner_ble_stop_scan();
        }

        public string GetDevices()
        {
            return ScannerBleC.inateck_scanner_ble_get_devices();
        }

        public string Connect(string mac, Callback callback)
        {
            return ScannerBleC.inateck_scanner_ble_connect(mac, callback);
        }

        public int Auth(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_auth(mac);
        }

        public int Disconnect(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_disconnect(mac);
        }

        public string GetBattery(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_battery(mac);
        }

        public string GetHardwareVersion(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_hardware_version(mac);
        }

        public string GetSoftwareVersion(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_software_version(mac);
        }

        public string GetSettingInfo(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_get_setting_info(mac);
        }

        public string SetSettingInfo(string mac, string cmd)
        {
            return ScannerBleC.inateck_scanner_ble_set_setting_info(mac, cmd);
        }

        public int SetName(string mac, string name)
        {
            return ScannerBleC.inateck_scanner_ble_set_name(mac, name);
        }

        public int SetTime(string mac, long time)
        {
            return ScannerBleC.inateck_scanner_ble_set_time(mac, time);
        }

        public int InventoryClearCache(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_clear_cache(mac);
        }

        public int InventoryUploadCache(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_upload_cache(mac);
        }

        public int InventoryUploadCacheNumber(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_inventory_upload_cache_number(mac);
        }

        public int Reset(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_reset(mac);
        }

        public int Restart(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_restart(mac);
        }

        public int CloseAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_close_all_code(mac);
        }

        public int OpenAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_open_all_code(mac);
        }

        public int ResetAllCode(string mac)
        {
            return ScannerBleC.inateck_scanner_ble_reset_all_code(mac);
        }

        public string SdkVersion()
        {
            return ScannerBleC.inateck_scanner_ble_sdk_version();
        }

        public string Debug(bool enable)
        {
            return ScannerBleC.inateck_scanner_ble_debug(enable);
        }
    }

    class ScannerBleC
    {
        const string LibPath = "./lib/libscanner_ble_x86_64-apple-darwin.dylib";
        
        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_init(Callback callback);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_destroy();

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_start_scan();

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_stop_scan();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_devices();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_connect(string mac, Callback callback);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_auth(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_disconnect(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_battery(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_hardware_version(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_software_version(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_get_setting_info(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_set_setting_info(string mac, string cmd);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_set_name(string mac, string name);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_set_time(string mac, long time);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_inventory_clear_cache(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_inventory_upload_cache(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_inventory_upload_cache_number(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_reset(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_restart(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_close_all_code(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_open_all_code(string mac);

        [DllImport(LibPath)]
        public static extern int inateck_scanner_ble_reset_all_code(string mac);

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_sdk_version();

        [DllImport(LibPath)]
        public static extern string inateck_scanner_ble_debug(bool enable);
    }
}
