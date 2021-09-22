using System;

namespace DotFetch.NET
{
    partial class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in LogoRenderer.Windows())
            {
                Console.WriteLine(item);
            }
        }
    }
}
