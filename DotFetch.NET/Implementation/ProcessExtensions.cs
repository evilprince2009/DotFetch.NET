using System.Diagnostics;

namespace DotFetch.NET.Implementation
{
    public static class ProcessExtensions
    {
        private static string FindIndexedProcessName(int process_id)
        {
            string process_name = Process.GetProcessById(process_id).ProcessName;
            Process[] processes_by_name = Process.GetProcessesByName(process_name);
            string process_indexed_name = string.Empty;
            
            for (int index = 0; index < processes_by_name.Length; index++)
            {
                process_indexed_name = index == 0 ? process_name : $"{process_name}#{index}";

                PerformanceCounter processId = new("Process", "ID Process", process_indexed_name);
                
                if ((int) processId.NextValue() == process_id)
                {
                    return process_indexed_name;
                }
            }

            return process_indexed_name;
        }
        
        private static Process FindPidFromIndexedProcessName(string indexed_process_name)
        {
            PerformanceCounter parent_id = new("Process", "Creating Process ID", indexed_process_name);
            return Process.GetProcessById((int)parent_id.NextValue());
        }
        
        public static Process Parent(this Process process) => FindPidFromIndexedProcessName(FindIndexedProcessName(process.Id));
    }
}