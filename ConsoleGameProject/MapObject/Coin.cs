using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Coin : MapObject, IAutoInteractable
{
    public Coin(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = '.';
        gettable = true;
        
    }

    public void Interact()
    {
        Game.Me.Balance += 100;
    }
}
