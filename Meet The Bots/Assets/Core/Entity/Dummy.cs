/**
 * @file       : Dummy.cs
 * @author     : Jakob P.
 * @description: This is just a test enemy that takes damage only
 * @note       : 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {
    public class Dummy : Entity, IEntity, IDamageable {
        Entity E => new Entity();

        /** 
        * @brief   Start is called before the first frame update
        */
        void Start() 
        {

        }

        public void Die()
        {
            this.gameObject.SetActive(false);
        }

        public void TakeDamage(DamageInfo d)
        {
            print("Took Damage: " + d.GetDamage());
        }
    }
}