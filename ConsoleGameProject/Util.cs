using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// 개발 시에 유용하게 쓰일 수 있는 기능을 모아둘 클래스입니다.
public static class Util
{
    // 텍스트에 색깔을 지정하여 문자가 일정 시간 간격을 두고 출력되도록 합니다.
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
