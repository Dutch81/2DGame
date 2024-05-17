//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyHealth : MonoBehaviour
//{
//    public int maxHealth = 1;
//    public int curHealth = 1;

//    public void EnemyDead()
//    {
//        curHealth = 0;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int curHealth;

    void Awake()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        Destroy(gameObject);
    }
}