using System.Collections.Generic;

namespace DotFetch.NET
{
    public class Combiner
    {
        public static List<string> InformationBuffer()
        {
            List<string> information = new();
            information.Add(InformationGenerator.UserAndComputerName());
            information.Add("--------------------------");
            information.Add(InformationGenerator.GetOS());
            information.Add(InformationGenerator.KernelVersion());
            information.Add(InformationGenerator.HostName());
            information.Add(InformationGenerator.UpTime());
            information.Add(InformationGenerator.GetPSVersion());
            information.Add(InformationGenerator.CPUInfo());
            information.Add(InformationGenerator.GetGPU());
            information.Add(InformationGenerator.AvailableRAM());
            information.Add(InformationGenerator.CheckDriveSpace());
            information.Add(InformationGenerator.CheckAdmin());
            information.Add(InformationGenerator.CheckInternetConnection());
            information.Add(InformationGenerator.CheckInternetIP());
            information.Add(InformationGenerator.CheckBatteryPower());


            return information;
        }
    }
}