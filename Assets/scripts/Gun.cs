using System.Collections;
using System.Collections.Generic;
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
    public bool isInvincible = false; // Changed to public
    public Renderer playerRenderer;
    public Color invincibleColor = Color.yellow;
    private Color originalColor;

    void Start()
    {
        Debug.Log("Initial bullet count: " + bulletCount);
        bulletText.text = "Bullets: " + bulletCount.ToString();

        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Current bullet count before shooting: " + bulletCount);

            if (bulletCount > 0)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
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



