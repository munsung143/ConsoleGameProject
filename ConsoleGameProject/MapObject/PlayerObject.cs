using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 맵 상에 P로 표시되는 플레이어 오브젝트 클래스입니다.
// 플레이어 클래스와 따로 관리됩니다.
public class PlayerObject : MapObject
{
    private int directionX;
    public int DirectionX { get { return directionX;  } set { directionX = value; } }
    private int directionY;
    public int DirectionY { get { return directionY; } set { directionY = value; } }
    private bool moveable;
    public bool Moveable { get { return moveable; } set { moveable = value; } }

    public int nextPosX => posX + directionX;
    public int nextPosY => posY + directionY;

    public PlayerObject(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'P';
        moveable = true;
    }
    public void Move()
    {
        if (moveable)
        {
            posX += directionX;
            posY += directionY;
            directionX = 0;
            directionY = 0;
        }
        Moveable = true;
    }

    public void SetPos(int y, int x)
    {
        posX = x;
        posY = y;
    }

    public void TryInteraction(IInteractable obj)
    {
        obj.Interact();
    }
    public void TryInteraction(IAutoInteractable obj)
    {
        obj.Interact();
    }
}