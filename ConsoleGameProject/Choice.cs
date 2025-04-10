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
    private int offset;

    public Choice()
    {
        offset = 0;
    }
    public Choice(int off)
    {
        offset = off;
    }
    public void Add(string choice)
    {
        Choices.Add(choice);
    }
    public void Clear()
    {
        Choices.Clear();
    }

    // 선택지 출력 후, 커서를 초기 위치에 출력합니다.
    public void Print()
    {
        foreach (string choice in Choices)
        {
            Console.SetCursorPosition(offset,Console.CursorTop);
            Console.WriteLine(choice);
        }
        cursorPos = Console.CursorTop - Choices.Count();
        choiceVal = 1;
        Console.SetCursorPosition(offset, cursorPos);
        Cursor();
        
    }

    // 커서를 출력합니다.
    public void Cursor()
    {
        Console.Write('>');
        Console.SetCursorPosition(offset, cursorPos);
    }

    // 커서가 출력될 위치를 위로 한 칸 올리고, 커서를 출력합니다.
    public void CursorUp()
    {
        if (choiceVal > 1)
        {
            Console.Write(" ");
            cursorPos--;
            choiceVal--;
            Console.SetCursorPosition(offset, cursorPos);
            Cursor();
        }
    }

    // 커서가 출력될 위치를 한 칸 내리고, 커서를 출력합니다.
    public void CursorDown()
    {
        if (choiceVal < Choices.Count())
        {
            Console.Write(" ");
            cursorPos++;
            choiceVal++;
            Console.SetCursorPosition(offset, cursorPos);
            Cursor();
        }
    }

    // 선택지가 출력됩니다. 키 입력을 받아 커서를 위, 아래로 움직일 수 있으며, 선택 후 엔터 시 
    // 해당 선택지 위치에 대한 정수를 반환합니다.
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
                case ConsoleKey.Escape:
                    return 0;
            }
        }
    }
}