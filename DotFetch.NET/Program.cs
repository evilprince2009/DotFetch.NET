using System;

namespace DotFetch.NET
{
    class Program
    {
        static void Main()
        {
            foreach (string line in Combiner.CombinedInformation())
            {
                Console.WriteLine(line);
            }
        }
    }
}
