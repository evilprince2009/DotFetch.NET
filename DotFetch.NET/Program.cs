using System;

namespace DotFetch.NET
{
    class Program
    {
        static void Main()
        {
            foreach (string info in Combiner.InformationBuffer())
            {
                Console.WriteLine(info);
            }
        }
    }
}
