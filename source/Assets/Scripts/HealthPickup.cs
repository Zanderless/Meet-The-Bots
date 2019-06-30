/**
 * @file       : HealthPickup.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    [Tooltip("How much health to give to the player")]
    public float health;

    private void OnTriggerEnter(Collider other)
    {

        Player player = other.GetComponent<Player>();

        if (player && player.Health < player.maxHealth)
        {
            other.GetComponent<Player>().AddHealth(health);
            Destroy(this.gameObject);
        }
    }

}
