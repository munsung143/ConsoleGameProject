using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NPC : MapObject, IInteractable
{
    public NPC(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'N';
    }
    public void Interact()
    {
        Game.Me.Health--;
    }
}