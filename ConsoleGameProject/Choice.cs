using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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