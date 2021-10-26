using System;
using System.Collections.Generic;

namespace DotFetch.NET.Implementation
{
    public class Combiner
    {
        private static string LineGenerator(int userAndHostNameLength)
        {
            List<string> linesBuffer = new();
            for (int i = 0; i < userAndHostNameLength; i++)
            {
                linesBuffer.Add("-");
            }

            return string.Join("", linesBuffer);
        }
        private static List<string> OsInformationBuffer()
        {
            List<string> information = new();
            information.Add(InformationGenerator.UserAndComputerName());
            information.Add(LineGenerator(InformationGenerator.UserAndComputerName().Length));
            information.Add(InformationGenerator.GetOS());
            information.Add(InformationGenerator.KernelVersion());
            information.Add(InformationGenerator.HostName());
            information.Add(InformationGenerator.UpTime());
            information.Add(InformationGenerator.GetPSVersion());
            information.Add(InformationGenerator.CPUInfo());
            information.Add(InformationGenerator.GetGPU());
            information.Add(InformationGenerator.RAMUsage());
            information.Add(InformationGenerator.CheckDriveSpace());
            information.Add(InformationGenerator.CheckAdmin());
            information.Add(InformationGenerator.CheckInternetConnection());
            information.Add(InformationGenerator.CheckInternetIP());
            information.Add(InformationGenerator.CheckBatteryPower());

            return information;
        }

        public static List<string> CombinedInformation()
        {
            List<string> combinedBuffer = new();
            List<string> balancedLogo = LogoRenderer.LogoAscii();
            List<string> balancedInfo = OsInformationBuffer();

            int logoHeight = LogoRenderer.LogoAscii().Count;
            int informationHeight = OsInformationBuffer().Count;
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
