/**
 * @file       : IDamageable.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public interface IDamageable {
        /** 
         * @brief   add damage to object
         * @param   d   amount of damage to add 
         */
        void TakeDamage(DamageInfo info);
    }
}