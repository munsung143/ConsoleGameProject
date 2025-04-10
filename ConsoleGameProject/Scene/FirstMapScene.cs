using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstMapScene : MapScene
{
    private string[] map;
    private List<MapObject> mapObjects;
    private ConsoleKey key;
    private PlayerObject player;
    private MapObject pickedUpObject;

    public FirstMapScene()
    {
        player = Game.MyObject;
        mapObjects = new List<MapObject>();
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

    // 포탈은 다음 씬에 대한 참조를 가져야 하기 때문에
    // 위의 생성자와 분리하여 따로 초기화했습니다.
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

    // 위의 맵을 그대로 출력하는 것이 아닌, 위의 맵을 바탕으로 리스트에 추가된
    // 맵 오브젝트 인스턴스들의 좌표, 심볼을 참조하여 출력합니다.
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
        Console.WriteLine("첫번째 맵");



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
                // 플레이어와 겹친 오브젝트를 불러와, 상호작용 시도.
                pickedUpObject = mapObjects.Find(obj => (obj.PosX == player.PosX) && (obj.PosY == player.PosY));
                if (pickedUpObject is IInteractable)
                {
                    player.TryInteraction(pickedUpObject as IInteractable);
                }
                break;
            case ConsoleKey.Escape:
                // 메뉴 오픈
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
