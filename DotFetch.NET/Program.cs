using System;

namespace DotFetch.NET
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("yo");
            foreach (string line in Combiner.CombinedInformation())
            {
                Console.WriteLine(line);
            }
        }
    }
}
