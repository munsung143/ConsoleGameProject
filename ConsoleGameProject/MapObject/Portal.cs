using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 맵 상에 X 으로 표시되는 포탈 클래스입니다.
public class Portal : MapObject, IInteractable
{
    private Scene nextScene;
    private int nextPosX;
    private int nextPosY;

    // 포탈은 해당 맵에서의 자신의 위치, 이동할 씬, 다음 씬에서의 플레이어의 위치 정보를 가집니다.
    public Portal(int y, int x, Scene next, int ny, int nx)
    {
        posX = x;
        posY = y;
        nextPosX = nx;
        nextPosY = ny;
        symbol = 'X';
        nextScene = next;
    }

    // 상호작용 시 씬을 다음 씬으로 넘기고, 플레이어의 위치 또한 바꿉니다.
    public void Interact()
    {
        Game.CurrentScene = nextScene;
        Game.MyObject.SetPos(nextPosY, nextPosX);

    }
}