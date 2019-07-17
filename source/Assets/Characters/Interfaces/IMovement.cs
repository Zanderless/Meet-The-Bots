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

        float MoveSpeed {get; set;}
        float StrafeSpeed { get; set; }
        float JumpHeight { get; set; }
        float Gravity { get; set; }


        /** 
         * @brief   move object
         */

        void Move(); 

        /** 
         * @brief   jump
         */
        
        void Jump(); 
        
        /** 
        * @brief   perform action
        */
        void Action();
    }
}