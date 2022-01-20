using System.Diagnostics;

namespace DotFetch.NET.Implementation
{
    public static class ProcessExtensions
    {
        private static string FindIndexedProcessName(int pid)
        {
            var processName = Process.GetProcessById(pid).ProcessName;
            var processesByName = Process.GetProcessesByName(processName);
            string? processIndexdName = null;
            
            for (var index = 0; index < processesByName.Length; index++)
            {
                processIndexdName = index == 0 ? processName : processName + "#" + index;
                PerformanceCounter processId = new("Process", "ID Process", processIndexdName);
                
                if ((int) processId.NextValue() == pid)
                {
                    return processIndexdName;
                }
            }

            return processIndexdName;
        }

    private static Process FindPidFromIndexedProcessName(string indexedProcessName)
    {
            PerformanceCounter parentId = new("Process", "Creating Process ID", indexedProcessName);
            return Process.GetProcessById((int)parentId.NextValue());
    }

    public static Process Parent(this Process process) => FindPidFromIndexedProcessName(FindIndexedProcessName(process.Id));

    }
}