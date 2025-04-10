using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 맵에 점 (.)으로 배치된 코인의 클래스
public class Coin : MapObject, IAutoInteractable
{
    public Coin(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = '.';
        gettable = true;
        
    }

    // 효과로 플레이어의 돈을 100원 향상시킵니다.
    public void Interact()
    {
        Game.Me.Balance += 100;
    }
}
