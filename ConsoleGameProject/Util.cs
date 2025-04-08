using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class Util
{
    public static void PrintEach(string str, ConsoleColor color, int letter, int sentence)
    {
        Console.ForegroundColor = color;
        foreach (char c in str)
        {
            Thread.Sleep(letter);
            Console.Write(c);
        }
        Console.WriteLine();
        Console.ResetColor();
        Thread.Sleep(sentence);
    }
}
