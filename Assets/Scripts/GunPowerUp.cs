using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        player.GetComponent<PlayerCombat>().ammo += 10;
        Destroy(gameObject);
    }
}
