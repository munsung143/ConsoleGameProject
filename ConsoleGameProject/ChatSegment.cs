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

    // 대화 아래에 뜰 선택지에 항목 추가
    public void AddChoice(string text)
    {
        choice.Add(text);
    }

    // 대화 내용 추가
    public void AddSentence(string text)
    {
        sentences.Add(text);
    }

    // 대화가 출력되기 전 해당 위치를 10칸 비웁니다.
    public void Clear()
    {
        for (int i = 0; i < 15; i++)
        {
            Console.SetCursorPosition(0, 10+i);
            Console.Write("                                                                  ");
        }
    }

    // 대화를 출력합니다.
    public void Render()
    {
        Console.SetCursorPosition(0, 15);
        foreach (var sentence in sentences)
        {
            Console.WriteLine(sentence);
        }
        Console.WriteLine();
    }

    // 대화 선택지를 출력하고, 선택값을 받습니다.
    public void Input()
    {
        input = choice.Start();
    }

    // 선택값을 반환합니다.
    public int ReturnInput()
    {
        return input;
    }
}
