using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChatSegment
{
    private List<string> sentences;
    private Choice choice;
    private int input;

    public ChatSegment()
    {
        sentences = new List<string>();
        choice = new Choice();
    }
    public void AddChoice(string text)
    {
        choice.Add(text);
    }
    public void AddSentence(string text)
    {
        sentences.Add(text);
    }

    public void Clear()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.SetCursorPosition(0, 10+i);
            Console.Write("                                                                  ");
        }
    }

    public void Render()
    {
        Console.SetCursorPosition(0, 10);
        foreach (var sentence in sentences)
        {
            Console.WriteLine(sentence);
        }
    }

    public void Input()
    {
        input = choice.Start();
    }

    public int ReturnInput()
    {
        return input;
    }
}
