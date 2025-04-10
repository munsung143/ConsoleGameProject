using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SecondMapScene : MapScene
{

    public SecondMapScene()
    {
        map = new string[]
        {
            "wwwwwwwwwwwwwwwwwwwww",
            "w           w       w",
            "w     c     w       w",
            "w        c  w       w",
            "w     c             w",
            "w 1         w       w",
            "w           w       w",
            "wwwwwwwwwwwwwwwwwwwww",
        };
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == 'w')
                {
                    mapObjects.Add(new Wall(i, j));
                }
                else if (map[i][j] == 'n')
                {
                    mapObjects.Add(new NPC(i, j));
                }
                else if (map[i][j] == 'c')
                {
                    mapObjects.Add(new Coin(i, j));
                }
            }
        }
    }

    public override void PortalInit()
    {
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '1')
                {
                    mapObjects.Add(new Portal(i, j, Game.scenes["FirstMap"], 3, 12));
                }
            }
        }
    }

    public override void Render()
    {
        base.Render();
        Console.WriteLine("[두 번째 맵]");
    }

}
