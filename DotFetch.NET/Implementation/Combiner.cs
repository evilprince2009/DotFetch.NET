namespace DotFetch.NET.Implementation
{
    public class Combiner
    {
        public static List<string> CombinedInformation()
        {
            List<string> combined_buffer = new();
            List<string> balanced_logo = LogoRenderer.LogoAscii();
            List<string> balanced_info = OsInformationBuffer();

            int logo_height = LogoRenderer.LogoAscii().Count;
            int info_height = OsInformationBuffer().Count;
            int height_difference = Math.Abs(logo_height - info_height);

            if (logo_height > info_height)
            {
                for (int i = 0; i < height_difference; i++)
                {
                    balanced_info.Add("");
                }
            }
            else if (info_height > logo_height)
            {
                for (int i = 0; i < height_difference; i++)
                {
                    balanced_logo.Add("");
                }
            }

            for (int i = 0; i < balanced_logo.Count; i++)
            {
                combined_buffer.Add($"{balanced_logo[i]} {balanced_info[i]}");
            }

            return combined_buffer;
        }

        private static List<string> OsInformationBuffer()
        {
            string lines = LineGenerator(InformationGenerator.GetUserAndComputerName());
            List<string> information = new()
            {
                InformationGenerator.GetUserAndComputerName(),
                lines,
                InformationGenerator.GetOS(),
                InformationGenerator.GetKernelVersion(),
                InformationGenerator.GetHostName(),
                InformationGenerator.GetUpTime(),
                InformationGenerator.GetShell(),
                InformationGenerator.GetTerminal(),
                InformationGenerator.GetCPUInfo(),
                InformationGenerator.GetGPU(),
                InformationGenerator.GetRAMUsage(),
                InformationGenerator.GetDriveSpace(),
                InformationGenerator.GetAdminRole(),
                InformationGenerator.GetInternetConnectivity(),
                InformationGenerator.GetInternetIP(),
                InformationGenerator.GetBatteryPower()
            };

            return information;
        }
        private static string LineGenerator(string username_and_host)
        {
            List<string> lines_buffer = new();
            for (int i = 0; i < username_and_host.Length; i++)
            {
                lines_buffer.Add("-");
            }

            return string.Join("", lines_buffer);
        }

        // Author: Ibne Nahian (evilprince2009)
    }
}

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
