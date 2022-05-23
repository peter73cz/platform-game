using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Names : MonoBehaviour
{
    private int i = 0;
    private List<string> names = new List<string>();
    private void Start()
    {
        names = GetComponent<Info>().names;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Name");
        foreach (GameObject thing in objects)
        {
            thing.GetComponent<Text>().text = names[i];
            i++;
        }
    }

}
