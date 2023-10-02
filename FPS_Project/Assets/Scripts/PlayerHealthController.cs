using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [SerializeField] int maxHealth, currentHealth;
    [SerializeField] float invincibleLenght = 1f;
    float invincCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0 && !FPS_GameManager.instance.levelEnding)
        {
            AudioManager.instance.PlaySFX(7);

            currentHealth -= damageAmount;

            UIController.instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                FPS_GameManager.instance.PlayerDied();

                AudioManager.instance.StopBGM();
                AudioManager.instance.PlaySFX(6);
                AudioManager.instance.StopSFX(7);
            }
            invincCounter = invincibleLenght;

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
        }    
    }

    public void HealthPlayer(int healthAmount)
    {
        currentHealth += healthAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "HEALTH: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
