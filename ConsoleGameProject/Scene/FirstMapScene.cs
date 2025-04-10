using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstMapScene : MapScene
{

    public FirstMapScene()
    {
        // 아래의 맵은 인스턴스 생성을 위한 가이드로서 사용됩니다.
        // 맵에 표시된 문자의 종류에 따라 생성되는 인스턴스의 종류가 달라집니다.
        map = new string[]
        {
            "wwwwwwwwwwwwwww",
            "w             w",
            "w             w",
            "w  p        2 w",
            "w             w",
            "w         n   w",
            "wwwwwwwwwwwwwww",
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
                else if (map[i][j] == 'p')
                {
                    player.SetPos(i, j);
                }
            }
        }
    }

    // 포탈은 다음 씬에 대한 참조를 가져오도록 되어 있어
    // 위의 생성자와 분리하여 따로 초기화합니다.
    public override void PortalInit()
    {
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '2')
                {
                    mapObjects.Add(new Portal(i, j, Game.scenes["SecondMap"], 5, 2));
                }
            }
        }
    }

    public override void Render()
    {
        base.Render();
        Console.WriteLine("[첫 번째 맵]");
    }



}
