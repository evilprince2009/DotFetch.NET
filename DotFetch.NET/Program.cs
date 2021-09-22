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
            
        }
    }
}
