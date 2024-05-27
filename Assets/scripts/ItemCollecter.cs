using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    private int Pineapples = 0;

    [SerializeField] private Text PineapplesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    
    private Gun2D gun;

    private void Start()
    {
        
        gun = GetComponent<Gun2D>();

        if (gun == null)
        {
            Debug.LogError("Gun2D script not found on the player.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Pineapples++;
            PineapplesText.text = "Coins: " + Pineapples;

            
            if (gun != null)
            {
                gun.ReloadBullets();
            }
        }
    }
}
