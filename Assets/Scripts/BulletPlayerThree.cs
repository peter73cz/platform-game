using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerThree : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamage playerDamege = collision.GetComponent<PlayerDamage>();
        if(playerDamege != null)
        {
            if (GameObject.Find("Player3") != null) GameObject.Find("Player4)").GetComponent<PlayerCombat>().score += playerDamege.TakeDamage(20);
            else GameObject.Find("Player3(Clone)").GetComponent<PlayerCombat>().score += playerDamege.TakeDamage(20);
        }
        Destroy(gameObject);
    }
}
