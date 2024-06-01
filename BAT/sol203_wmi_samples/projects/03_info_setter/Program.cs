using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace _03_info_setter
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObject drive_c = new ManagementObject(@"\\.\root\CIMV2:Win32_LogicalDisk.DeviceID=""C:""");
            drive_c["VolumeName"] = "My Label";
            drive_c.Put();
        }
    }
}
