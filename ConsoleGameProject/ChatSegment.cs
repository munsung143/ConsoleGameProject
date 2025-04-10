using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NPC와 대화 시 맵 화면 아래에 출력되는 대화의 한 장면에 대한 클래스입니다.
// 만들어진 인스턴스들은 NPC 클래스의 스택을 통해 관리됩니다.
// Scene과 비슷합니다.
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
        Console.WriteLine();
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
