/**
 * @file       : HealthPickup.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public class HealthPickup : BaseItem {

        [Tooltip("How much health to give to the player")]
        public float health;

        /**
         * @brief   when item has triggered an event
         * @param   other       object which has triggered item event      
         */
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
}
