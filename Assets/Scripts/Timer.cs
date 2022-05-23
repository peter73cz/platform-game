using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text text;
    float currentTime;
    void Start()
    {
        currentTime = GetComponent<Info>().time;
    }

    void Update()
    {
        currentTime -=1 * Time.deltaTime;
        
        if(currentTime > 60)
        {
            text.fontSize = 100;
            text.text = (int)currentTime / 60 + ":" + (int)currentTime % 60;
        }
        else
        {
            text.text = ((int)currentTime).ToString();
        }
        if (currentTime < 10) text.color = Color.yellow;

        if(currentTime < 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("End");
        }

    }
}
