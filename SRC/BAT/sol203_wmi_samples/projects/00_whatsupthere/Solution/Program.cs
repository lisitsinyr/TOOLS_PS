using System;
using System.Collections.Generic;
using System.Text;

using _0_mac.ROOT.CIMV2;
using System.Management;

namespace _0_mac
{
	class Program
	{
		static void Main(string[] args)
		{
            //foreach (NetworkAdapter na in NetworkAdapter.GetInstances())
            //{
            //    Console.WriteLine(na.MACAddress);
            //}

            ManagementClass mc = new ManagementClass(@"\\.\root\CIMV2:Win32_NetworkAdapter");
            foreach (ManagementObject mo in mc.GetInstances())
            {
                Console.WriteLine(mo.GetPropertyValue("MACAddress"));    
            }

            ManagementClass mc1 = new ManagementClass(@"\\.\root\CIMV2:Win32_LogicalDisk");
            foreach (ManagementObject mo in mc1.GetInstances())
            {
                Console.WriteLine(mo.GetPropertyValue("FreeSpace"));
            }
        }
	}
}
