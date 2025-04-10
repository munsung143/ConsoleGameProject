using System;
using System.Collections.Generic;

// 게임의 초기화와 게임 실행을 관리하는 클래스입니다.
public static class Game
{
    private static bool gameEnd;
    public static bool GameEnd { get { return gameEnd; } set { gameEnd = value; } }
    private static bool gameOver;
    private static Scene currentScene;
    public static Scene CurrentScene {  get { return currentScene; } set { currentScene = value; } }
    public static Dictionary<string, Scene> scenes;
    private static Player me;
    public static Player Me { get  { return me; } set { me = value; } }

    private static PlayerObject myObject;
    public static PlayerObject MyObject { get { return myObject; }}


    public static void Init()
    {
        gameEnd = false;
        gameOver = false;
        myObject = new PlayerObject(0, 0);
        scenes = new Dictionary<string, Scene>();
        scenes.Add("Title", new TitleScene());
        scenes.Add("Name", new NameScene());
        scenes.Add("FirstMap", new FirstMapScene());
        scenes.Add("SecondMap", new SecondMapScene());
        (scenes["FirstMap"] as MapScene).PortalInit();
        (scenes["SecondMap"] as MapScene).PortalInit();
        currentScene = scenes["Title"];
        Menu.Init();
        Inventory.Init();
        Inventory.AddItem(new Potion("HP5 회복포션", 5));
        Inventory.AddItem(new Potion("HP10 회복포션", 10));
        Inventory.AddItem(new Potion("HP15 회복포션", 15));
        Inventory.AddItem(new Potion("HP20 회복포션", 20));
    }
    public static void Run()
    {
        while (!gameEnd)
        {
            currentScene.Render();
            currentScene.Input();
            currentScene.Update();
        }
    }


}

