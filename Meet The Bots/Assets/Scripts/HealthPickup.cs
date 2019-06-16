using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    [Tooltip("How much health to give to the player")]
    public float health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().AddHealth(health);
            Destroy(this.gameObject);
        }
    }

}
