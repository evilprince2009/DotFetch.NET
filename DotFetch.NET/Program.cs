using DotFetch.NET.Implementation;

Console.WriteLine(Environment.NewLine);

foreach (string line in Combiner.CombinedInformation())
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t" + line);
}

Console.ResetColor();

// Author: Ibne Nahian (evilprince2009)

/* _______ ____
  | __/ _ \| __|
  | _| (_) | _|
  |___\___/|_|
*/
