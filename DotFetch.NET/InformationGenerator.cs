using System;
using System.Management;


namespace DotFetch.NET
{
    public class InformationGenerator
    {
        public static string GetOS()
        {
            const string query = "SELECT Caption FROM Win32_OperatingSystem";
            string result = string.Empty;
            ManagementObjectSearcher searcher =
                new(query);
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

        public static string HostName()
        {
            const string scope = "root\\CIMV2";
            const string query = "SELECT * FROM Win32_BaseBoard";
            ManagementObjectSearcher searcher = new(scope, query);
            foreach (ManagementObject informationBuffer in searcher.Get())
            {
                return "Host: " + informationBuffer.GetPropertyValue("Manufacturer").ToString();
            }

            return "Host: Unknown";
        }

        public static string UpTime()
        {
            const string path = @"\\.\root\cimv2:Win32_OperatingSystem=@";
            ManagementObject marker = new(path);
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(marker["LastBootUpTime"].ToString());
            var timeStamp = DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
            string[] duration =
            {
                "Uptime:", timeStamp.Days.ToString(), "Days", timeStamp.Hours.ToString(), "Hours",
                timeStamp.Minutes.ToString(), "Minutes"
            };

            return string.Join(" ", duration);
        }

        public static string CPUInfo()
        {
            const string query = "select * from Win32_Processor";
            ManagementObjectCollection moc = new ManagementObjectSearcher(query).Get();
            
            foreach (ManagementObject obj in moc)
            {
                try
                {
                    return "CPU: " + obj["Name"].ToString();
                }
                catch {}
            }

            return "Couldn't detect !";
        }
        // CALCULATE AVAILABLE RAM
        public static string AvailableRAM()
        {
            const string query = "SELECT * FROM Win32_OperatingSystem";
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject o in searcher.Get())
            {
                var os = (ManagementObject) o;
                var totalRam = os["TotalVisibleMemorySize"];
                var freeRam = os["FreePhysicalMemory"];
                var usedRam = Convert.ToInt64(totalRam) - Convert.ToInt64(freeRam);
                return "RAM: " + usedRam + "MB / " + totalRam + "MB";
            }
            return "RAM: Unknown";
        }

        // check internet connection
        public static string CheckInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return "Internet: Connected";
                    }
                }
            }
            catch
            {
                return "Internet: Offline";
            }
        }
    }
}