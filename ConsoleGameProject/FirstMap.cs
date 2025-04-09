using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstMap : Map
{
    private string[] map;
    private List<MapObject> mapObjects;
    private ConsoleKey key;
    private PlayerObject player;

    public FirstMap()
    {
        mapObjects = new List<MapObject>();
        map = new string[]
        {
            "wwwwwwwwwwwwwww",
            "w             w",
            "w             w",
            "w  p          w",
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
                    player = new PlayerObject(i, j);
                }
            }
        }
    }

    public override void Render()
    {
        Console.Clear();
        Game.Me.PrintInfo();
        foreach (MapObject obj in mapObjects)
        {
            Console.SetCursorPosition(obj.PosX, obj.PosY);
            Console.Write(obj.Symbol);
        }
        Console.SetCursorPosition(player.PosX, player.PosY);
        Console.Write(player.Symbol);



    }
    public override void Input()
    {
        key = Console.ReadKey(true).Key;

    }
    public override void Update()
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                player.DirectionX = 0;
                player.DirectionY = -1;
                break;
            case ConsoleKey.DownArrow:
                player.DirectionX = 0;
                player.DirectionY = 1;
                break;
            case ConsoleKey.LeftArrow:
                player.DirectionX = -1;
                player.DirectionY = 0;
                break;
            case ConsoleKey.RightArrow:
                player.DirectionX = 1;
                player.DirectionY = 0;
                break;
            default:
                player.DirectionX = 0;
                player.DirectionY = 0;
                break;
        }
        // 플레이어 이동 방향의 오브젝트를 불러와, 그것이 벽이라면 이동 불가로 설정.
        player.Moveable = true;
        MapObject obj = mapObjects.Find(x => (x.PosX == player.nextPosX) && (x.PosY == player.nextPosY));
        if (obj is Wall)
        {
            player.Moveable = false;
        }
        player.Move();

    }

}
