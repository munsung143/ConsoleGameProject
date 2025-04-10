using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Potion : Item
{
    private int healAmount;
    public Potion(string name, int healAmount)
    {
        consumable = true;
        this.name = name;
        this.healAmount = healAmount;
    }
    public override void Effect()
    {
        Game.Me.Heal(this.healAmount);
    }
}
