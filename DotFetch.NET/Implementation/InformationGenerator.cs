using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace DotFetch.NET.Implementation
{
    public class InformationGenerator
    {
        private static Dictionary<string, string> QueryString()
        {
            Dictionary<string, string> buffer = new();
            buffer.Add("os", "SELECT Caption FROM Win32_OperatingSystem");
            buffer.Add("gpu", "SELECT * FROM Win32_VideoController");
            buffer.Add("scope", "root\\CIMV2");
            buffer.Add("host", "SELECT * FROM Win32_BaseBoard");
            buffer.Add("path", @"\\.\root\cimv2:Win32_OperatingSystem=@");
            buffer.Add("cpu", "Select * from Win32_Processor");
            buffer.Add("ram", "SELECT * FROM Win32_OperatingSystem");
            buffer.Add("url", "https://api.ipify.org");
            buffer.Add("battery", "SELECT * FROM Win32_Battery");
            buffer.Add("nf", "Couldn't detect");

            return buffer;
        }

        // Getting Operating System
        public static string GetOS()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher =
                new(QueryString()["os"]);
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }

            result = $"OS: {result.Remove(0, 10)}";
            return result;
        }

        // Get PS version
        public static string GetShell()
        {
            string buffer = GetParentProcess().ProcessName;
            string shell = $"{buffer[..1].ToUpper()}{buffer[1..]}";
            return $"Shell: {shell}";
        }

        // Gettting Client Terminal
        public static string GetTerminal()
        {
            string buffer = GetParentProcess().Parent().ProcessName;
            string terminal = $"{buffer[..1].ToUpper()}{buffer[1..]}";
            if (terminal == "Explorer") terminal = "Windows Console";
            return $"Terminal: {terminal}";
        }

        // Getting GPU information
        public static string GetGPU()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new(QueryString()["gpu"]);
            foreach (ManagementObject gpu in searcher.Get())
            {
                result = gpu["Name"].ToString();
                break;
            }
            return $"GPU: {result}";
        }

        // Getting Kernel build
        public static string GetKernelVersion()
        {
            return $"Kernel Version: {Environment.OSVersion.Version}";
        }

        // Getting Host Manufacturer
        public static string GetHostName()
        {
            ManagementObjectSearcher searcher = new(QueryString()["scope"], QueryString()["host"]);
            foreach (ManagementObject informationBuffer in searcher.Get())
            {
                if (informationBuffer != null) return $"Host: {informationBuffer.GetPropertyValue("Manufacturer")}";
            }

            return $"Host: {QueryString()["nf"]}";
        }

        // Getting machine uptime
        public static string GetUpTime()
        {
            ManagementObject marker = new(QueryString()["path"]);
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(marker["LastBootUpTime"].ToString());
            var timeStamp = DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
            return
                $"Uptime: {timeStamp.Days} Days {timeStamp.Hours} Hours {timeStamp.Minutes} Minutes";
        }

        // Checking CPU information
        public static string GetCPUInfo()
        {
            ManagementObjectCollection objectCollection = new ManagementObjectSearcher(QueryString()["cpu"]).Get();

            foreach (ManagementObject item in objectCollection)
            {
                try
                {
                    return $"CPU: {item["Name"]}";
                }
                catch { }
            }

            return $"CPU: {QueryString()["nf"]}";
        }

        // Calculate available RAM
        public static string GetRAMUsage()
        {
            const long divider = 1024 * 1024;
            ManagementObjectSearcher searcher = new(QueryString()["ram"]);
            foreach (ManagementObject os in searcher.Get())
            {
                var totalRam = os["TotalVisibleMemorySize"];
                var freeRam = os["FreePhysicalMemory"];
                string diskUsage = $"{Convert.ToInt64(freeRam) / divider}GB / {Convert.ToInt64(totalRam) / divider}GB";
                return $"Memory: {diskUsage}";
            }
            return $"Memory: {QueryString()["nf"]}";
        }

        // Check internet connection
        public static string GetInternetConnectivity()
        {
            const string label = "Internet Access";
            return NetworkInterface.GetIsNetworkAvailable() ? $"{label}: Connected" : $"{label}: Offline";
        }

        // Check Internet IP
        public static string GetInternetIP()
        {
            string ip = "127.0.0.1";
            if (GetInternetConnectivity() == "Internet Access: Offline")
                return $"IP: {ip}";

            HttpClient response = new();
            ip = response.GetStringAsync(QueryString()["url"]).Result;
            return $"IP: {ip}";
        }

        // Check C:\ Drive space
        public static string GetDriveSpace()
        {
            const long divider = 1024 * 1024 * 1024;
            var drive = new DriveInfo(@"C:\");
            var freeSpace = drive.TotalFreeSpace / divider;
            var totalSpace = drive.TotalSize / divider;
            var used = (totalSpace - freeSpace) * 100 / totalSpace;
            return $"Disk (C:): {freeSpace}GB / {totalSpace}GB ({used}% used)";
        }

        // Information generator
        // Author: Ibne Nahian (evilprince2009)

        // AC power status
        private static string CheckBatteryCharging()
        {
            ManagementObjectSearcher searcher = new(QueryString()["battery"]);
            foreach (ManagementObject battery in searcher.Get())
            {
                var batteryLife = battery["BatteryStatus"];
                if (batteryLife.ToString() == "2")
                {
                    return "Connected";
                }

                return "Unplugged";
            }
            return QueryString()["nf"];
        }

        // Check available battery power
        public static string GetBatteryPower()
        {
            ManagementObjectSearcher searcher = new(QueryString()["battery"]);
            foreach (ManagementObject battery in searcher.Get())
            {
                var batteryLife = battery["EstimatedChargeRemaining"];
                return $"Power: {batteryLife}% , {CheckBatteryCharging()}";
            }
            return $"Power: {QueryString()["nf"]}";
        }

        // Get computer and username
        public static string GetUserAndComputerName()
        {
            return $"{Environment.UserName}@{Environment.MachineName}";
        }

        // Check if PowerShell is running as Admin
        public static string GetAdminRole()
        {
            string role = new WindowsPrincipal(WindowsIdentity
                .GetCurrent())
                .IsInRole(WindowsBuiltInRole
                    .Administrator)
                ? "Yes"
                : "No";
            return $"Running as Admin: {role}";
        }

        // Detect Parent process
        private static Process GetParentProcess() => Process.GetProcessesByName("DotFetch.NET")[0].Parent();
    }
}

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
