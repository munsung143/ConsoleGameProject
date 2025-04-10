using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class MapObject
{
    protected int posX;
    public int PosX { get { return posX; } set { posX = value; } }
    protected int posY;
    public int PosY { get { return posY; } set { posY = value; } }
    protected char symbol;
    public char Symbol { get { return symbol; } }
}