using System;

// 플레이어의 정보 및 정보의 출력을 관리하는 클래스입니다.
public class Player
{
    private string name;
    public string Name { get { return name; } set { name = value; } }
    private int level;
    public int Level { get { return level; } set { level = value; } }
    private int health;
    public int Health { get { return health; } set { health = value; } }
    private int balance;
    public int Balance { get { return balance; } set { balance = value; } }

    private int offset = 60;

    public Player(string name)
    {
        this.name = name;
        this.level = 1;
        this.health = 20;
        this.balance = 1000;
    }

    public void PrintInfo()
    {
        Console.WriteLine();
        Console.SetCursorPosition(offset, Console.CursorTop);
        Console.WriteLine($"이름 : {name}");
        Console.SetCursorPosition(offset, Console.CursorTop);
        Console.WriteLine($"레벨 : {level}");
        Console.SetCursorPosition(offset, Console.CursorTop);
        Console.WriteLine($"체력 : {health}");
        Console.SetCursorPosition(offset, Console.CursorTop);
        Console.WriteLine($"돈 : {balance}원");
    }
}
