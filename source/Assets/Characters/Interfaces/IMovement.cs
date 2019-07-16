/**
 * @file       : IMovement.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public interface IMovement {

        private float MoveSpeed => 10f;
        private float StrafeSpeed => 7f;
        private float JumpHeight => 8f;
        private float Gravity => 20f;


        /** 
         * @brief   move object
         */
        
        void move(); 

        /** 
         * @brief   jump
         */
        
        void jump(); 
        
        /** 
        * @brief   perform action
        */
        void action();
    }
}