using UnityEngine;
using UnityEngine.UI;

public class InvincibilityTimer : MonoBehaviour
{
    public Text invincibilityTimerText;
    private float remainingTime;
    private bool isInvincibilityActive;

    private void Start()
    {
        invincibilityTimerText.text = "";
    }

    private void Update()
    {
        if (isInvincibilityActive)
        {
            remainingTime -= Time.deltaTime;
            invincibilityTimerText.text = "Invincible: " + Mathf.Max(remainingTime, 0).ToString("F1") + "s";

            if (remainingTime <= 0)
            {
                EndInvincibility();
            }
        }
    }

    public void StartInvincibility(float duration)
    {
        remainingTime = duration;
        isInvincibilityActive = true;
        invincibilityTimerText.gameObject.SetActive(true);
    }

    private void EndInvincibility()
    {
        isInvincibilityActive = false;
        invincibilityTimerText.text = "";
        invincibilityTimerText.gameObject.SetActive(false);
    }
}

