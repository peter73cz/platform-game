using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public Animator animator;
    Transform spawnPoint;
    Transform center;
    public Image healthBar;

    public SpriteRenderer sr;
    public CharacterController2D controller;
    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;

    public Rigidbody2D rb;

    public Sprite live;
    public Sprite dead;
    public Image image;

    public int respawnDelay = 5;
    public int maxHealth = 100;
    public int currentHealth;
    bool alive = true;

    int point = 1;

    void Start()
    {
        currentHealth = maxHealth;

        GameObject temp = GameObject.Find("Spawnpoint");   
        spawnPoint = temp.GetComponent<Transform>();

        GameObject temp2 = GameObject.Find("Center");
        center = temp2.GetComponent<Transform>();
    }

    void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        if (transform.position.y < -10)
        {
            alive = false;
            image.sprite = dead;
            transform.position = center.position;       // Transport the player to the center of playgroud, bicouse I dont know how to remove him
            sr.enabled = false;                         // If the player fall from playground the grave wont be visible
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Invoke("Respawn", respawnDelay);            // Start Respawn menthod after time
        }
    }
    public int TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (alive)
        {
            // Play hurt animation
            animator.SetTrigger("Damage");

            if (currentHealth <= 0)
            {
                animator.SetBool("IsDead", true);       // Play Dead animation
                alive = false;
                image.sprite = dead;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;  // After dead player cant move and stay on one place
                controller.enabled = false;
                playerCombat.enabled = false;
                playerMovement.enabled = false;
                Invoke("Respawn", respawnDelay);        // Start Respawn menthod after time

                return point;                           // Returt point to the player who kills this one
            }
        }
        return 0;                                      
    }
 
    public void Respawn()
    {
            sr.enabled = true;
            controller.enabled = true;
            playerCombat.enabled = true;
            playerMovement.enabled = true;
            alive = true;
            image.sprite = live;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;             // Restore player movements
            currentHealth = maxHealth;                                          // Restore health
            transform.position = spawnPoint.position;                           // Transport player to the spawnpoint
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;    
            animator.SetBool("IsDead", false);                                  // Turn off the dead animation


    }
}
