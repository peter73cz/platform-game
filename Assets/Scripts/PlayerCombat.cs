using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public GameObject bulletPrefab;
    public int ammo = 5;

    public Text scoreCounter;

    public static PlayerCombat instace;
    public int score = 0;

    void Start()
    {
        instace = this;
    }
    void Update()
    {
        if (ammo > 0) animator.SetLayerWeight(1,1);
        else animator.SetLayerWeight(1,0);

        if (Time.time >= nextAttackTime)
        {
            if ((Input.GetKeyDown(KeyCode.Space) && gameObject.layer == 8) | (Input.GetKeyDown(KeyCode.AltGr) && gameObject.layer == 9) | (Input.GetKeyDown(KeyCode.Keypad0) && gameObject.layer == 10) | (Input.GetKeyDown(KeyCode.O) && gameObject.layer == 11))
            {
                if (ammo > 0) Shot();                
                else Attack();
            }
        }
        scoreCounter.text = "Score:" + score;
    }

    void Attack()
    {

        // Play an attack animation
        animator.SetBool("Attack", true);

        // animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies) 
        {
            // Get point for kill
           score += enemy.GetComponent<PlayerDamage>().TakeDamage(attackDamage);
        }

        nextAttackTime = Time.time + 1f / attackRate;
    }

    void Shot()
    {
        // Play an shot animation
        animator.SetBool("Attack", true);

        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        ammo--;

        nextAttackTime = Time.time + 1f / (attackRate * 2);
    }

    // Show attack in editor
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
