using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !collected)
        {
            PlayerController.instance.activeGun.GetAmmo();

            Destroy(gameObject);

            collected = true;

            AudioManager.instance.PlaySFX(3);
        }
    }
}