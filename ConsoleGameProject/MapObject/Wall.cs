using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Wall : MapObject
{
    public Wall(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'W';
    }
}