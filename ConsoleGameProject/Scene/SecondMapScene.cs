using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SecondMapScene : Scene
{
    private string[] map;
    private List<MapObject> mapObjects;
    private ConsoleKey key;
    private PlayerObject player;
    private MapObject pickedUpObject;

    public SecondMapScene()
    {
        player = Game.MyObject;
        mapObjects = new List<MapObject>();
        map = new string[]
        {
            "wwwwwwwwwwwwwwwwwwwww",
            "w           w       w",
            "w           w       w",
            "w           w       w",
            "w                   w",
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
            }
        }
    }

    public void PortalInit()
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
        Console.Clear();
        Game.Me.PrintInfo();
        foreach (MapObject obj in mapObjects)
        {
            Console.SetCursorPosition(obj.PosX, obj.PosY);
            Console.Write(obj.Symbol);
        }
        Console.SetCursorPosition(player.PosX, player.PosY);
        Console.Write(player.Symbol);
        Console.SetCursorPosition(0, map.Length);
        Console.WriteLine("두번째 맵");



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
            case ConsoleKey.Enter:
                pickedUpObject = mapObjects.Find(obj => (obj.PosX == player.PosX) && (obj.PosY == player.PosY));
                if (pickedUpObject is IInteractable)
                {
                    player.TryInteraction(pickedUpObject as IInteractable);
                }
                break;
            case ConsoleKey.Escape:
                Menu.Open();
                break;
            default:
                break;
        }
        // 플레이어 이동 방향의 오브젝트를 불러와, 그것이 벽이라면 이동 불가로 설정.
        pickedUpObject = mapObjects.Find(obj => (obj.PosX == player.nextPosX) && (obj.PosY == player.nextPosY));
        if (pickedUpObject is Wall)
        {
            player.Moveable = false;
        }
        player.Move();
        pickedUpObject = null;
    }
}
