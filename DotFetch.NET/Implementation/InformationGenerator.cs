using System;
using System.IO;
using System.Management;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace DotFetch.NET.Implementation
{
    public class InformationGenerator
    {
        // Getting Operating System
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

            result = $"OS: {result.Remove(0, 10)}";
            return result;
        }

        // Getting GPU information
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
            return $"GPU: {result}";
        }

        // Getting Kernel build
        public static string KernelVersion()
        {
            return $"Kernel Version: {Environment.OSVersion.Version}";
        }

        // Getting Host Manufacturer
        public static string HostName()
        {
            const string scope = "root\\CIMV2";
            const string query = "SELECT * FROM Win32_BaseBoard";
            ManagementObjectSearcher searcher = new(scope, query);
            foreach (ManagementObject informationBuffer in searcher.Get())
            {
                if (informationBuffer != null) return $"Host: {informationBuffer.GetPropertyValue("Manufacturer")}";
            }

            return "Host: Unknown";
        }

        // Getting machine uptime
        public static string UpTime()
        {
            const string path = @"\\.\root\cimv2:Win32_OperatingSystem=@";
            ManagementObject marker = new(path);
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(marker["LastBootUpTime"].ToString());
            var timeStamp = DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
            return
                $"Uptime: {timeStamp.Days} Days {timeStamp.Hours} Hours {timeStamp.Minutes} Minutes";
        }

        // Checking CPU information
        public static string CPUInfo()
        {
            const string query = "select * from Win32_Processor";
            ManagementObjectCollection objectCollection = new ManagementObjectSearcher(query).Get();

            foreach (ManagementObject item in objectCollection)
            {
                try
                {
                    return $"CPU: {item["Name"]}";
                }
                catch { }
            }

            return "Couldn't detect !";
        }

        // CALCULATE AVAILABLE RAM
        public static string RAMUsage()
        {
            const long divider = 1024 * 1024;
            const string query = "SELECT * FROM Win32_OperatingSystem";
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject os in searcher.Get())
            {
                var totalRam = os["TotalVisibleMemorySize"];
                var freeRam = os["FreePhysicalMemory"];
                string diskUsage = $"{Convert.ToInt64(freeRam) / divider}GB / {Convert.ToInt64(totalRam) / divider}GB";
                return $"Memory: {diskUsage}";
            }
            return "Memory: Unknown";
        }

        // Check internet connection
        public static string CheckInternetConnection()
        {
            const string label = "Internet Access";
            return NetworkInterface.GetIsNetworkAvailable() ? $"{label}: Connected" : $"{label}: Offline";
        }

        // Check Internet IP
        public static string CheckInternetIP()
        {
            const string url = "https://api.ipify.org";
            string ip = "127.0.0.1";
            if (CheckInternetConnection() == "Internet Access: Offline")
                return $"IP: {ip}";

            HttpClient response = new();
            ip = response.GetStringAsync(url).Result;
            return $"IP: {ip}";
        }

        // Check C:\ Drive space
        public static string CheckDriveSpace()
        {
            const long divider = 1024 * 1024 * 1024;
            var drive = new DriveInfo(@"C:\");
            var freeSpace = (drive.TotalFreeSpace) / divider;
            var totalSpace = (drive.TotalSize) / divider;
            var used = (totalSpace - freeSpace) * 100 / totalSpace;
            return $"Disk (C:): {freeSpace}GB / {totalSpace}GB ({used}% used)";
        }

        // Information generator
        // Author: Ibne Nahian (evilprince2009)

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

        // Check available battery power
        public static string CheckBatteryPower()
        {
            const string query = "SELECT * FROM Win32_Battery";
            ManagementObjectSearcher searcher = new(query);
            foreach (ManagementObject battery in searcher.Get())
            {
                var batteryLife = battery["EstimatedChargeRemaining"];
                return $"Power: {batteryLife}% , {CheckBatteryCharging()}";
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
            return $"{GetUserName()}@{GetComputerName()}";
        }

        // Check if PowerShell is running as Admin
        public static string CheckAdmin()
        {
            string role = new WindowsPrincipal(WindowsIdentity
                .GetCurrent())
                .IsInRole(WindowsBuiltInRole
                    .Administrator)
                ? "Yes"
                : "No";
            return $"Running as Admin: {role}";
        }
    }
}

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
