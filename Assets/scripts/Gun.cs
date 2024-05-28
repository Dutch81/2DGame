using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int bulletCount = 3;
    private int maxBullets = 3;
    public Text bulletText;

    public int pineappleCount = 0;
    public float invincibilityDuration = 5.0f;
    public bool isInvincible = false;
    public Renderer playerRenderer;
    public Color invincibleColor = Color.yellow;
    private Color originalColor;

    private InvincibilityTimer invincibilityTimer;

    private bool facingRight = true;  // Track the direction the player is facing
    public Vector3 rightBulletSpawnOffset = new Vector3(0.5f, 0, 0);  // Offset when facing right
    public Vector3 leftBulletSpawnOffset = new Vector3(-0.5f, 0, 0);  // Offset when facing left

    void Start()
    {
        Debug.Log("Initial bullet count: " + bulletCount);
        bulletText.text = "Bullets: " + bulletCount.ToString();

        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;

        invincibilityTimer = FindObjectOfType<InvincibilityTimer>();
    }

    void Update()
    {
        // Track player movement direction
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            facingRight = true;
        }
        else if (horizontalInput < 0)
        {
            facingRight = false;
        }

        // Update bullet spawn point based on facing direction
        bulletSpawnPoint.localPosition = facingRight ? rightBulletSpawnOffset : leftBulletSpawnOffset;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Current bullet count before shooting: " + bulletCount);

            if (bulletCount > 0)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                // Set bullet direction based on player facing direction
                if (facingRight)
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
                }

                bulletCount--;
                Debug.Log("Bullet shot! Remaining bullets: " + bulletCount);
                bulletText.text = "Bullets: " + bulletCount.ToString();
            }
            else
            {
                Debug.Log("I need more bullets");
            }
        }
    }

    public void ReloadBullets()
    {
        bulletCount = maxBullets;
        Debug.Log("Bullets reloaded! Current bullet count: " + bulletCount);
        bulletText.text = "Bullets: " + bulletCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pineapple"))
        {
            pineappleCount++;
            Destroy(other.gameObject);

            if (pineappleCount >= 5)
            {
                pineappleCount = 0;
                StartCoroutine(ActivateInvincibility());
            }
        }
    }

    IEnumerator ActivateInvincibility()
    {
        isInvincible = true;
        playerRenderer.material.color = invincibleColor;
        Debug.Log("Invincibility Activated");

        invincibilityTimer.StartInvincibility(invincibilityDuration);

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
        playerRenderer.material.color = originalColor;
        Debug.Log("Invincibility Ended");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HandleCollisionWithEnemy();
        }
    }

    void HandleCollisionWithEnemy()
    {
        if (isInvincible)
        {
            Debug.Log("Collision with enemy ignored due to invincibility");
        }
        else
        {
            Debug.Log("Collision with enemy, taking damage");
        }
    }
}





