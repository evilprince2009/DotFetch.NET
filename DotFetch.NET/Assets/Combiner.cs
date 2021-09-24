using System;
using System.Collections.Generic;

namespace DotFetch.NET.Assets
{
    public class Combiner
    {
        private static List<string> OSInformationBuffer()
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
            //information.Add(InformationGenerator.CheckInternetIP());
            information.Add(InformationGenerator.CheckBatteryPower());

            return information;
        }

        public static List<string> CombinedInformation()
        {
            List<string> combinedBuffer = new();
            List<string> balancedLogo = LogoRenderer.LogoAscii();
            List<string> balancedInfo = OSInformationBuffer();

            int logoHeight = LogoRenderer.LogoAscii().Count;
            int informationHeight = OSInformationBuffer().Count;
            int heightDifference = Math.Abs(logoHeight - informationHeight);

            if (logoHeight > informationHeight)
            {
                for (int i = 0; i < heightDifference; i++)
                {
                    balancedInfo.Add("");
                }
            }
            else if (informationHeight > logoHeight)
            {
                for (int i = 0; i < heightDifference; i++)
                {
                    balancedLogo.Add("");
                }
            }

            for (int i = 0; i < balancedLogo.Count; i++)
            {
                combinedBuffer.Add($"{balancedLogo[i]} {balancedInfo[i]}");
            }

            return combinedBuffer;
        }

        // Author: Ibne Nahian (evilprince2009)
    }
}

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
