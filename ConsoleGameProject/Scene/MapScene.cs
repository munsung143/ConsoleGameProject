using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class MapScene : Scene
{
    protected string[] map;
    protected List<MapObject> mapObjects;
    protected ConsoleKey key;
    protected PlayerObject player;
    protected MapObject pickedUpObject;
    public abstract void PortalInit();

    public MapScene()
    {
        player = Game.MyObject;
        mapObjects = new List<MapObject>();
    }

    // string[] map을 그대로 출력하는 것이 아닌, string[] map 을 바탕으로 리스트에 추가된
    // 맵 오브젝트 인스턴스들의 멤버인 좌표, 심볼을 참조하여 출력합니다.
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
        Console.WriteLine("이동 : 방향키 상호작용/선택 : enter 메뉴 : esc");
        Console.WriteLine("엔피시 : N 포탈 : X 동전 : .");
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
        // 플레이어와 겹친 오브젝트를 불러와, 자동 상호작용 시도.
        pickedUpObject = mapObjects.Find(obj => (obj.PosX == player.PosX) && (obj.PosY == player.PosY));
        if (pickedUpObject is IAutoInteractable)
        {
            player.TryInteraction(pickedUpObject as IAutoInteractable);
            if (pickedUpObject.Gettable)
            {
                mapObjects.Remove(pickedUpObject);
            }
        }
        pickedUpObject = null;
    }
}
