using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// 개발 시에 유용하게 쓰일 수 있는 기능을 모아둘 클래스입니다.
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
