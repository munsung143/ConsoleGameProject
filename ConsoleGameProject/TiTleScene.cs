using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TitleScene : CommentScene
{
    Choice choice;
    private int input;
    public override void Render()
    {
        Console.Clear();
        Console.WriteLine("********************");
        Console.WriteLine();
        Console.WriteLine("   콘솔 게임 프로젝트 ");
        Console.WriteLine();
        Console.WriteLine("********************");
        Console.WriteLine();
        PrintChoice();
    }
    public void PrintChoice()
    {
        choice = new Choice();
        choice.Add("     1. 게임 시작");
        choice.Add("     2. 게임 종료");
    }
    public override void Input()
    {
        input = choice.Start();
        PrintReselt();
    }
    public  void PrintReselt()
    {
        switch (input)
        {
            case 1:
                Util.PrintEach("잠시 후 게임이 시작됩니다...", ConsoleColor.Green, 50, 1000);
                break;
            case 2:
                Util.PrintEach("잠시 후 게임이 종료됩니다...", ConsoleColor.Red, 50, 1000);
                break;
        }
    }
    public  void Waiting()
    {
    }
    public override void Update()
    {
        switch (input)
        {
            case 1:
                Game.CurrentScene = Game.scenes["Name"];
                break;
            case 2:
                Game.GameEnd = true;
                break;
        }
    }
}