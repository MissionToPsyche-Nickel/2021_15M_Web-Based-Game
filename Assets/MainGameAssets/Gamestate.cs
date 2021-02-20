using System.Collections;
using System.Collections.Generic;

public class Gamestate
{
    public static readonly Gamestate instance = new Gamestate();

    public bool tutorialCompleted = false;
    public int gameProgress = 0;

    private Gamestate()
    {
        LoadData();
    }
    
    public void OnApplicationQuit()
    {
        SaveData();
    }

    public void LoadData()
    {
        // this would run code to load from file
    }

    public void SaveData()
    {
        // this would run code to save to file
    }
}
