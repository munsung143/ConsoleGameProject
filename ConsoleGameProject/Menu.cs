using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 씬에서 esc를 누르게 되면 나오는 메뉴 클래스입니다.
public static class Menu
{
    private static Choice choice;
    private static int input;
    private static bool close;

    // 메뉴의 기본 선택지 세팅
    public static void Init()
    {
        choice = new Choice();
        choice.Add("     1. 돌아가기");
        choice.Add("     2. 타이틀(게임초기화)");
        choice.Add("     3. 인벤토리");
    }

    // 메뉴 선택지 출력 전 해당 위치를 깔끔하게 비운다.
    public static void Clear()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(0, 0+i);
            Console.WriteLine("                              ");
        }
        Console.SetCursorPosition(0, 0);
    }

    // 선택지 출력 및 선택
    public static void Input()
    {
        input = choice.Start();
    }

    // 선택값에 따라 다름 행동을 결정합니다.
    public static void Next()
    {
        switch (input)
        {
            case 0:
            case 1:
                close = true;
                break;
            case 2:
                close = true;
                Game.Init();
                break;
            case 3:
                Inventory.Open();
                break;
        }
    }

    // 메뉴를 엽니다. 메뉴가 꺼질때까지 반복됩니다.
    public static void Open()
    {
        close = false;
        while (!close)
        {
            Clear();
            Input();
            Next();
        }

    }
}