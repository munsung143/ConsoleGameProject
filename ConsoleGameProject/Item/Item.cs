using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 인벤토리에 들어가는 아이템의 추상 클래스입니다.
public abstract class Item
{
    protected string name;
    public string Name { get { return name; } }
    protected bool consumable = false;
    public bool Counsumable { get { return consumable; } }
    public abstract void Effect();
}