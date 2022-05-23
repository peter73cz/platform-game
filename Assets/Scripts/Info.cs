using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    static int numberOfPlayers = 1;
    public int players;

    static int playTime = 60;
    public int time;

    static List<string> playersNames = new List<string>();
    public List<string> names = new List<string>();

    public void NumberOfPlayers(int players)
    {
        numberOfPlayers = players;
    }
    public void Time(int time)
    {
        playTime = time;
    }
    public void Names(string n)
    {
        playersNames.Add(n);
    }

    public void Awake()
    {
        players = numberOfPlayers;
        time = playTime;
        names = playersNames;
    }

}
