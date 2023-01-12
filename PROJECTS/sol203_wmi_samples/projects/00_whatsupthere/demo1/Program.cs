using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using demo1.ROOT.CIMV2;


namespace demo1
{
    class Program
    {
        public static void Main() {
            foreach (NetworkAdapter na in NetworkAdapter.GetInstances()) {
                Console.WriteLine(na.MACAddress);
            }

            foreach (LogicalDisk ld in LogicalDisk.GetInstances())
            {
                Console.WriteLine(string.Format("{0} {1}",ld.FreeSpace, ld.FileSystem));
            }

        }
    }
}
