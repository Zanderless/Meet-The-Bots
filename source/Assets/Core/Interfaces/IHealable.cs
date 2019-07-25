/**
 * @file       : IHealable.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public interface IHealable {

        /** 
         * @brief   add health to object
         * @param   h   amount of health to add 
         */
        void AddHealth(float h);
        
        /** 
         * @brief   add armor to object
         * @param   a   amount of armor to add 
         */        
         void AddArmor(float a);
    }
}