using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    private Vector3 position;
    private Vector3 puvodni;
    private float time;
    private int i;
    void Start()
    {
        puvodni = transform.position; 
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time > 1)
        {
            position.x += 0.1f;
            transform.position = position;
            time = 0;
            i++;
        }
        if(i > 120)
        {
            position = puvodni;
            i = 1;
        }

    }
}
