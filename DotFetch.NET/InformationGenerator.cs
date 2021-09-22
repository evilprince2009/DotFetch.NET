using System;
using System.Management;

namespace DotFetch.NET
{
    public class InformationGenerator
    {
        public static string GetOS()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher =
                new ("SELECT Caption FROM Win32_OperatingSystem");
            foreach (var o in searcher.Get())
            {
                var os = (ManagementObject) o;
                result = os["Caption"].ToString();
                break;
            }

            result = "OS: " + result.Remove(0, 10);
            return result;
        }

        public static string KernelVersion()
        {
            return "Kernel Version: " + Environment.OSVersion.Version.ToString();
        }
    }
}