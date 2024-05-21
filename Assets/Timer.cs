using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0f;
    [SerializeField] private float startingTime = 60f;

    [SerializeField] private Text countdownText;
    [SerializeField] private PLayerLife player;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time Left: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            player.Die();
        }
    }
}