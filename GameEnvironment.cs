using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> toppers = new List<GameObject>();
    private List<GameObject> botters = new List<GameObject>();
    private List<GameObject> deadBotters = new List<GameObject> ();
    public List<GameObject> Toppers { get { return toppers; } }
    public List<GameObject> Botters { get { return botters; } }
    public List<GameObject> DeadBotters { get { return deadBotters; } }


    public static GameEnvironment Singleton 
    { 
        get { 
            if (instance == null) 
            { 
                instance = new GameEnvironment(); 
            } 
            return instance; 
        } 
    }

    public void AddTopper(GameObject topper)
    {
        toppers.Add(topper);
    }

    public void RemoveTopper(GameObject topper)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = toppers.IndexOf(topper);
        toppers.RemoveAt(index);
    }

    public void AddBotter(GameObject botter)
    {
        botters.Add(botter);
    }

    public void RemoveBotter(GameObject botter)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = botters.IndexOf(botter);
        botters.RemoveAt(index);
    }

    public void AddDeadBotter(GameObject deadBotter)
    {
        deadBotters.Add(deadBotter);
    }

    public void RemoveDeadBotter(GameObject deadBotter)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = deadBotters.IndexOf(deadBotter);
        deadBotters.RemoveAt(index);
    }



}
