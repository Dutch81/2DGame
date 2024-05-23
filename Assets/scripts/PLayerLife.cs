using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Gun2D gunScript;

    [SerializeField] private AudioSource deathSoundEffect;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (!gunScript.isInvincible)
        {
            healthBar.SetHealth(0);
            deathSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            RestartLevel();
        }
        else
        {
            return;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int maxHealth = 3;
    public int currentHealth = 3;

    public HealthBar healthBar;





    public void TakeDamage(int damage)
    {
        if (!gunScript.isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
                GetComponent<PlayerMovement>().enabled = false;
            }
        }
        else
        {
            return;
        }

    }
}