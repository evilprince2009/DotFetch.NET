﻿using System;
using DotFetch.NET.Assets;

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
        // Author: Ibne Nahian (evilprince2009)
    }
}
