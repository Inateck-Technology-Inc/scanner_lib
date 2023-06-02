#pragma warning disable CS8500
#pragma warning disable CS8981
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CsBindgen
{
    internal delegate void ConnectCallback(IntPtr result);

    internal static unsafe partial class NativeMethods
    {
        const string __DllName = "scanner_windows.dll";

        [DllImport(__DllName, EntryPoint = "scan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* scan();

        [DllImport(__DllName, EntryPoint = "connect", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* connect(byte* device_id, byte* app_id, byte* developer_id, byte* app_key, ConnectCallback callback);


        [DllImport(__DllName, EntryPoint = "disconnect", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* disconnect(byte* device_id);

        [DllImport(__DllName, EntryPoint = "get_basic_properties", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* get_basic_properties(byte* device_id, byte* property_key);

        [DllImport(__DllName, EntryPoint = "get_properties_info_by_key", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* get_properties_info_by_key(byte* device_id, byte* property_key);

        [DllImport(__DllName, EntryPoint = "edit_properties_info_by_key", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* edit_properties_info_by_key(byte* device_id, byte* property_key, byte* data);

        [DllImport(__DllName, EntryPoint = "get_all_barcode_properties", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* get_all_barcode_properties(byte* device_id);

        [DllImport(__DllName, EntryPoint = "get_basic_device_info", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte* get_basic_device_info(byte* device_id);


    

        static void Main(string[] args)
        {
            byte* ptr = scan();
            string result = new string((sbyte*)ptr);
            Console.WriteLine(result);

          
            byte[] deviceIdArray = Encoding.ASCII.GetBytes("7B:AA:8C:98:10:71");
            byte[] appIdArray = Encoding.ASCII.GetBytes("***");
            byte[] developerIdArray = Encoding.ASCII.GetBytes("***");
            byte[] appKeyArray = Encoding.ASCII.GetBytes("***");


            unsafe
            {
                fixed (byte* pDeviceId = deviceIdArray)
                fixed (byte* pAppId = appIdArray)
                fixed (byte* pDeveloperId = developerIdArray)
                fixed (byte* pAppKey = appKeyArray)
                {
                    byte* functionResult = connect(pDeviceId, pAppId, pDeveloperId, pAppKey, Callback);
                    result = new string((sbyte*)functionResult);
                    Console.WriteLine(result);
                }
            }
          

            Console.WriteLine("test end");
        }

        static void Callback(IntPtr result)
        {
            string resultString = Marshal.PtrToStringAnsi(result);
            Console.WriteLine("Callback result: " + resultString);
        }

    }



}
