using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Image player1;
    public Sprite p1;
    public Sprite p1bw;

    public Image player2;
    public Sprite p2;
    public Sprite p2bw;

    public Image player3;
    public Sprite p3;
    public Sprite p3bw;

    public Image player4;
    public Sprite p4;
    public Sprite p4bw;

    private string name1 = "Player 1", name2 = "Player 2", name3 = "Player 3", name4 = "Player 4";

    public void PlayGame()
    {
        /*
        FindObjectOfType<Info>().Names(name1);
        FindObjectOfType<Info>().Names(name2);
        FindObjectOfType<Info>().Names(name3);
        FindObjectOfType<Info>().Names(name4);
        */
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void OnePlayerButton()
    {
        FindObjectOfType<Info>().NumberOfPlayers(1);
        player1.sprite = p1;
        player2.sprite = p2bw;
        player3.sprite = p3bw;
        player4.sprite = p4bw;


    }

    public void TwoPlayersButton()
    {
        FindObjectOfType<Info>().NumberOfPlayers(2);
        player1.sprite = p1;
        player2.sprite = p2;
        player3.sprite = p3bw;
        player4.sprite = p4bw;
    }
    public void ThreePlayersButton()
    {
        FindObjectOfType<Info>().NumberOfPlayers(3);
        player1.sprite = p1;
        player2.sprite = p2;
        player3.sprite = p3;
        player4.sprite = p4bw;
    }
    public void FourPlayesButton()
    {
        FindObjectOfType<Info>().NumberOfPlayers(4);
        player1.sprite = p1;
        player2.sprite = p2;
        player3.sprite = p3;
        player4.sprite = p4;
    }

    public void OneMinute()
    {
        FindObjectOfType<Info>().Time(60);
    }
    public void TwoMinutes()
    {
        FindObjectOfType<Info>().Time(120);
    }
    public void ThreeMinutes()
    {
        FindObjectOfType<Info>().Time(180);
    }

    public void NameOne(string text)
    {
        name1 = text;
    }
    public void NameTwo(string text)
    {
        name2 = text;
    }
    public void NameThree(string text)
    {
        name3 = text;
    }
    public void NameFour(string text)
    {
        name4 = text;
    }
}
