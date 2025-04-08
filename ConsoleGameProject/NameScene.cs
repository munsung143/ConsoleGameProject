using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NameScene : CommentScene
{
    private string input;
    public override void Render()
    {
        Console.Clear();
        Console.Write("이름을 입력해주세요 : ");
    }
    public override void Input()
    {
        input = Console.ReadLine();
    }
    public override void Update()
    {
        Game.Me = new Player(input);
    }
}