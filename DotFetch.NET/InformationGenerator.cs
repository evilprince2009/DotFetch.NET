﻿using System;
using System.Management;
using System.Diagnostics;

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

        public static string HostName()
        {
            ManagementObjectSearcher searcher = new ("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject informationBuffer in searcher.Get())
            {
                return "Host: " + informationBuffer.GetPropertyValue("Manufacturer").ToString();
            }

            return "Host: Unknown";
        }

        public static string GetUptime()
        {
            ManagementObject marker = new (@"\\.\root\cimv2:Win32_OperatingSystem=@");
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(marker["LastBootUpTime"].ToString());
            return (DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime()).ToString();
        }
    }
}