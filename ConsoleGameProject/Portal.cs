using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Portal : MapObject, IInteractable
{
    private Scene nextScene;
    private int nextPosX;
    private int nextPosY;
    public Portal(int y, int x, Scene next, int ny, int nx)
    {
        posX = x;
        posY = y;
        nextPosX = nx;
        nextPosY = ny;
        symbol = '.';
        nextScene = next;
    }
    public void Interact()
    {
        Game.CurrentScene = nextScene;
        Game.MyObject.SetPos(nextPosY, nextPosX);

    }
}