using System;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Principal;


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
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }

            result = "OS: " + result.Remove(0, 10);
            return result;
        }

        // get gpu information
        public static string GetGPU()
        {
            const string query = "SELECT * FROM Win32_VideoController";
            string result = string.Empty;
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject gpu in searcher.Get())
            {
                result = gpu["Name"].ToString();
                break;
            }
            return "GPU: " + result;
        }

        public static string KernelVersion()
        {
            return "Kernel Version: " + Environment.OSVersion.Version;
        }

        public static string HostName()
        {
            const string scope = "root\\CIMV2";
            const string query = "SELECT * FROM Win32_BaseBoard";
            ManagementObjectSearcher searcher = new(scope, query);
            foreach (ManagementObject informationBuffer in searcher.Get())
            {
                return "Host: " + informationBuffer.GetPropertyValue("Manufacturer");
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
            ManagementObjectCollection objectCollection = new ManagementObjectSearcher(query).Get();
            
            foreach (ManagementObject obj in objectCollection)
            {
                try
                {
                    return "CPU: " + obj["Name"];
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
            foreach (ManagementObject os in searcher.Get())
            {
                
                var totalRam = os["TotalVisibleMemorySize"];
                var freeRam = os["FreePhysicalMemory"];
                return "Memory: " + (Convert.ToInt64(freeRam) / (1024 * 1024)) + "GB / " + (Convert.ToInt64(totalRam) / (1024 * 1024)) + "GB";
            }
            return "Memory: Unknown";
        }

        // check internet connection
        public static string CheckInternetConnection()
        {
            const string url = "http://www.google.com";
            try
            {
                using var client = new WebClient();
                using var stream = client.OpenRead(url);
                return "Internet Access: Connected";
            }
            catch
            {
                return "Internet Access: Offline";
            }
        }

        // Check internet ip
        public static string CheckInternetIP()
        {
            const string url = "http://checkip.dyndns.org";
            try
            {
                using var client = new WebClient();
                var html = client.DownloadString(url);
                var ip = html.Split(':')[1].Split('<')[0];
                return "IP: " + ip;
            }
            catch
            {
                return "IP: 127.0.0.1";
            }
        }

        // Check C:\ drive space
        public static string CheckDriveSpace()
        {
            var drive = new DriveInfo("C:\\");
            var freeSpace = (drive.TotalFreeSpace) / (1024 * 1024 * 1024);
            var totalSpace = (drive.TotalSize) / (1024 * 1024 * 1024);
            return "Disk (C:): " + freeSpace + " GB" + " / " + totalSpace + " GB";
        }

        // AC power status
        private static string CheckBatteryCharging()
        {
            const string query = "SELECT * FROM Win32_Battery";
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject battery in searcher.Get())
            {
                var batteryLife = battery["BatteryStatus"];
                if (batteryLife.ToString() == "2")
                {
                    return "Connected";
                }

                return "Unplugged";
            }
            return "Unknown";
        }

        // check available battery power
        public static string CheckBatteryPower()
        {
            const string query = "SELECT * FROM Win32_Battery";
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject battery in searcher.Get())
            {
                var batteryLife = battery["EstimatedChargeRemaining"];
                return "Power: " + batteryLife + "% , " + CheckBatteryCharging();
            }
            return "Power: Unknown";
        }

        // Get computer name
        private static string GetComputerName()
        {
            return Environment.MachineName;
        }

        // Get user name
        private static string GetUserName()
        {
            return Environment.UserName;
        }

        // get ps version
        public static string GetPSVersion()
        {
            return "PowerShell: " + Environment.Version;
        }

        public static string UserAndComputerName()
        {
            return GetUserName() + "@" + GetComputerName();
        }

        // Check if powershell is running as admin
        public static string CheckAdmin()
        {
            return "Running as Admin: " + (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? "Yes" : "No");
        }
    }
}