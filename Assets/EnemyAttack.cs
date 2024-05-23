using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;
    public float knockbackForce = 10f;

    Animator anim;
    GameObject player;
    PLayerLife playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    Rigidbody playerRigidbody;
    public Animation attackAnimation;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PLayerLife>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.curHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            Gun2D playerGunScript = player.GetComponent<Gun2D>();

            if (playerGunScript != null && !playerGunScript.isInvincible)
            {
                attackAnimation.Play();
                playerHealth.TakeDamage(attackDamage);
                ApplyKnockback();
            }
            else
            {
                Debug.Log("Player is invincible, no damage applied.");
                return;
            }
        }
    }

    void ApplyKnockback()
    {
        Vector3 knockbackDirection = (player.transform.position - transform.position).normalized;
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
    }
}
