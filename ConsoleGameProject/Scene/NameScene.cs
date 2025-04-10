using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 이름을 입력받아 플레이어 인스턴스를 생성하는 씬입니다.
public class NameScene : Scene
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
        Game.CurrentScene = Game.scenes["FirstMap"];
    }
}