/**
To use this json reader you need to create an empty game object and attach this script to it. Then use the editor to put the journal.json file in as the jsonFile variable.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("JournalJsonReaderTest")]

[Serializable]
public class JournalPage
{
    public int page;
    public string title;
    public string image;
    public string text;
}

[System.Serializable]
public class Pages
{
    public JournalPage[] pages;
}


public class JournalJsonReader : MonoBehaviour
{

    //Need to put the journal.json file in the jsonFile variable of the JournalJasonReader script
    public TextAsset jsonFile;

    void Start()
    {
        pagelist = LoadPagesFromFile();
    }

    internal Pages pagelist;

    internal Pages LoadPagesFromFile()
    {
        Assert.IsNotNull(jsonFile);
        
        Pages journalPages = JsonUtility.FromJson<Pages>(jsonFile.text);

        foreach (JournalPage page in journalPages.pages)
            {
                Debug.Log("Successfully loaded page " + page.page + " " + page.title);
            }
        return journalPages;
    }

    private static JournalJsonReader jsonReader;
    public static JournalJsonReader Instance()
    {
        if (!jsonReader)
        {
            jsonReader = FindObjectOfType(typeof(JournalJsonReader)) as JournalJsonReader;
        }
        if (!jsonReader)
        {
            Debug.Log("Journal json reader not working.");
        }
        return jsonReader;
    }
}
