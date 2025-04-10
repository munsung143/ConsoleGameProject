using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 포션 클래스입니다.
public class Potion : Item
{
    private int healAmount;
    public Potion(string name, int healAmount)
    {
        consumable = true;
        this.name = name;
        this.healAmount = healAmount;
    }
    // 사용 효과로 플레이어 클래스의 Heal()함수를 불러와 플레이어를 회복시킵니다.
    public override void Effect()
    {
        Game.Me.Heal(this.healAmount);
    }
}
