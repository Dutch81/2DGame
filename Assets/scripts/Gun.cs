using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int bulletCount = 3;  // Initial bullet count
    private int maxBullets = 3;  // Max bullets the gun can hold

    void Start()
    {
        Debug.Log("Initial bullet count: " + bulletCount); // Log the initial bullet count
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Current bullet count before shooting: " + bulletCount); // Log the bullet count before attempting to shoot

            if (bulletCount > 0)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
                bulletCount--;
                Debug.Log("Bullet shot! Remaining bullets: " + bulletCount); // Log the remaining bullet count after shooting
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
        Debug.Log("Bullets reloaded! Current bullet count: " + bulletCount); // Log the bullet count after reloading
    }
}

