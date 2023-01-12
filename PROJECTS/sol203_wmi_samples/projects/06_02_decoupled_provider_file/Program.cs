using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management.Instrumentation;
using System.Management;
using System.IO;

namespace _07_decoupled_provider
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       //[STAThread]
        static void Main()
        {
            InstrumentationManager.RegisterAssembly(typeof(BmfFile).Assembly);

            CheckObjects();

            Console.WriteLine("provider is up and running");
            Console.ReadLine();

            InstrumentationManager.UnregisterAssembly(typeof(BmfFile).Assembly);

        }

        private static void CheckObjects()
        {
            ManagementClass mc = new ManagementClass(@"\\.\root\bmf_StringProvider:BmfString");
            foreach (ManagementObject mo in mc.GetInstances())
            {
                object value = mo.GetPropertyValue("Size");
                Console.WriteLine(string.Format("Size of {0} is {1}", mo.GetPropertyValue("String"), value));
            }
            Console.WriteLine();

            ManagementClass mc1 = new ManagementClass(@"\\.\root\bmf_StringProvider:BmfFile");
            foreach (ManagementObject mo1 in mc1.GetInstances())
            {
                object value = mo1.GetPropertyValue("Size");
                Console.WriteLine(string.Format("Size of {0} is {1}", mo1.GetPropertyValue("String"), value));
            }

            Console.WriteLine();
            
            ManagementObject mo2 = new ManagementObject(@"\\.\root\bmf_StringProvider:BmfString.String='vasya alekseev'");
            object value1 = mo2.GetPropertyValue("Size");
            Console.WriteLine(string.Format("Size of {0} is {1}", "vasya alekseev", value1));
        }
    }
}
