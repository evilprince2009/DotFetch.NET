using System;

namespace DotFetch.NET
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("                                 =========> Wellcome || Windows PowerShell <=========");
            Console.WriteLine(InformationGenerator.CPUInfo());
            Console.WriteLine(InformationGenerator.HostName());
            Console.WriteLine(InformationGenerator.GetOS());
            Console.WriteLine(InformationGenerator.HostName());
            Console.WriteLine(InformationGenerator.KernelVersion());
            Console.WriteLine(InformationGenerator.UpTime());
            Console.WriteLine(InformationGenerator.AvailableRAM());
            Console.WriteLine(InformationGenerator.CheckInternetConnection());
            Console.WriteLine(InformationGenerator.CheckInternetIP());
            Console.WriteLine(InformationGenerator.CheckDriveSpace());
            Console.WriteLine(InformationGenerator.CheckBatteryPower());            
            Console.WriteLine(InformationGenerator.UserAndComputerName());            
            Console.WriteLine(InformationGenerator.CheckAdmin());            
                        
            Console.WriteLine(InformationGenerator.GetGPU());            
            Console.WriteLine(InformationGenerator.GetPSVersion());
        }
    }
}
