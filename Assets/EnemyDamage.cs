using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PLayerLife playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
