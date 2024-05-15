using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
     private int Pineapples = 0;

    [SerializeField] private Text PineapplesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Pineapples++;
            PineapplesText.text = "Pineapples: " + Pineapples;
        }
    }
}
