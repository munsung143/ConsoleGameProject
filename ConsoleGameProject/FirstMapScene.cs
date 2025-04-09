using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstMapScene : MapScene
{
    private Map map;
    private bool leaveScene;

    public FirstMapScene()
    {
        map = Game.maps["FirstMap"];
        leaveScene = false;
    }
    public override void Render()
    {
        while (!leaveScene)
        {
            map.Render();
            map.Input();
            map.Update();
        }
    }
    public override void Input()
    {
        
    }
    public override void Update()
    {

    }
}
