using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthAmount;

    bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isCollected)
        {
            PlayerHealthController.instance.HealthPlayer(healthAmount);

            Destroy(gameObject);

            AudioManager.instance.PlaySFX(5);
        }
    }
}
