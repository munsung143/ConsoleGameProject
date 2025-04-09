using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerObject : MapObject
{
    public PlayerObject(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'P';
    }
    public void Interact()
    {

    }
}