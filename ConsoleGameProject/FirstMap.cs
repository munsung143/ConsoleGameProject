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
            "w             w",
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
        switch (key)
        {
            case ConsoleKey.UpArrow:
                player.PosY--;
                break;
            case ConsoleKey.DownArrow:
                break;
            case ConsoleKey.LeftArrow:
                break;
            case ConsoleKey.RightArrow:
                break;
        }


    }
    public override void Update()
    {

    }

}
