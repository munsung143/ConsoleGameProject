using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Menu
{
    private static Choice choice;
    private static int input;
    private static bool endMenu;


    public static void Init()
    {
        choice = new Choice();
        choice.Add("     1. 돌아가기");
        choice.Add("     2. 타이틀(게임초기화)");
        choice.Add("     3. 인벤토리");
    }
    public static void Clear()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(0, 0+i);
            Console.WriteLine("               ");
        }
        Console.SetCursorPosition(0, 0);
    }

    public static void Input()
    {
        input = choice.Start();
    }
    public static void Next()
    {
        switch (input)
        {
            case 1:
                endMenu = true;
                break;
            case 2:
                endMenu = true;
                Game.Init();
                break;
            case 3:
                break;
        }
    }
    public static void Open()
    {
        endMenu = false;
        while (!endMenu)
        {
            Clear();
            Input();
            Next();
        }

    }
}