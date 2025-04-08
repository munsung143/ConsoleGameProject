using System;
using System.Collections.Generic;

public static class Game
{
    private static bool gameEnd;
    public static bool GameEnd { get { return gameEnd; } set { gameEnd = value; } }
    private static bool gameOver;
    private static Scene currentScene;
    public static Scene CurrentScene {  get { return currentScene; } set { currentScene = value; } }
    public static Dictionary<string, Scene> scenes;
    public static Dictionary<string, Map> maps;
    private static Player me;
    public static Player Me { get  { return me; } set { me = value; } }

    public static void Init()
    {
        gameEnd = false;
        gameOver = false;
        scenes = new Dictionary<string, Scene>();
        maps = new Dictionary<string, Map>();
        maps.Add("FirstMap", new FirstMap());
        scenes.Add("Title", new TitleScene());
        scenes.Add("Name", new NameScene());
        scenes.Add("FirstMap", new FirstMapScene());
        currentScene = scenes["Title"];
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

