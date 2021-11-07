using System;
using System.Collections.Generic;

namespace DotFetch.NET.Implementation
{
    public class Combiner
    {
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

        private static List<string> OsInformationBuffer()
        {
            List<string> information = new();
            information.Add(InformationGenerator.GetUserAndComputerName());
            information.Add(LineGenerator(InformationGenerator.GetUserAndComputerName()));
            information.Add(InformationGenerator.GetOS());
            information.Add(InformationGenerator.GetKernelVersion());
            information.Add(InformationGenerator.GetHostName());
            information.Add(InformationGenerator.GetUpTime());
            information.Add(InformationGenerator.GetShell());
            information.Add(InformationGenerator.GetTerminal());
            information.Add(InformationGenerator.GetCPUInfo());
            information.Add(InformationGenerator.GetGPU());
            information.Add(InformationGenerator.GetRAMUsage());
            information.Add(InformationGenerator.GetDriveSpace());
            information.Add(InformationGenerator.GetAdminRole());
            information.Add(InformationGenerator.GetInternetConnectivity());
            information.Add(InformationGenerator.GetInternetIP());
            information.Add(InformationGenerator.GetBatteryPower());

            return information;
        }
        private static string LineGenerator(string userAndHostName)
        {
            List<string> linesBuffer = new();
            for (int i = 0; i < userAndHostName.Length; i++)
            {
                linesBuffer.Add("-");
            }

            return string.Join("", linesBuffer);
        }

        // Author: Ibne Nahian (evilprince2009)
    }
}

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
