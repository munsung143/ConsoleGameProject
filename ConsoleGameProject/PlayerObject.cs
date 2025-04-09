using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    public void Move()
    {
        if (moveable)
        {
            posX += directionX;
            posY += directionY;
        }
    }
}