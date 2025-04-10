using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 타이틀 화면, 메뉴, 대화 시에 쓰이는 선택지에 대한 클래스입니다.
// 원하는 만큼 항목 추가가 가능하며,
// 항목 출력, 항목 선택 후 엔터 시 해당 항목의 번호(순서)에 대한 정수를 반환하는 기능이 있습니다.
public class Choice
{
    private ConsoleKey key;
    private List<string> Choices = new List<string>();
    public int ChoicesCount { get { return Choices.Count; } }
    private int cursorPos = 0;
    private int choiceVal = 0;
    public void Add(string choice)
    {
        Choices.Add(choice);
    }
    public void Print()
    {
        foreach (string choice in Choices)
        {
            Console.WriteLine(choice);
        }
        cursorPos = Console.CursorTop - Choices.Count();
        choiceVal = 1;
        Console.SetCursorPosition(0, cursorPos);
        Cursor();
    }
    public void Cursor()
    {
        Console.Write('>');
        Console.SetCursorPosition(0, cursorPos);
    }
    public void CursorUp()
    {
        if (choiceVal > 1)
        {
            Console.Write(" ");
            cursorPos--;
            choiceVal--;
            Console.SetCursorPosition(0, cursorPos);
            Cursor();
        }
    }
    public void CursorDown()
    {
        if (choiceVal < Choices.Count())
        {
            Console.Write(" ");
            cursorPos++;
            choiceVal++;
            Console.SetCursorPosition(0, cursorPos);
            Cursor();
        }
    }
    public int Start()
    {
        Print();
        while (true)
        {
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    CursorUp();
                    break;
                case ConsoleKey.DownArrow:
                    CursorDown();
                    break;
                case ConsoleKey.Enter:
                    Console.SetCursorPosition(0, cursorPos + (Choices.Count - choiceVal) + 2);
                    return choiceVal;
            }
        }
    }
}