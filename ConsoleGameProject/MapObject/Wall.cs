using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 맵 상에 W로 표시되는 벽 클래스입니다.
public class Wall : MapObject
{
    public Wall(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'W';
    }
}