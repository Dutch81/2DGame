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

    void Start()
    {
        Debug.Log("Initial bullet count: " + bulletCount);
        bulletText.text = "Bullets: " + bulletCount.ToString();
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
}

