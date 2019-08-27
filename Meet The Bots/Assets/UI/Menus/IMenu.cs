/**
 * @file       : IMenu.cs
 * @author     :
 * @description: Menu Interface
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public interface IMenu {

        /**
         * @brief   Construct a new menu 
         */
        void Construct();

        /**
         * @brief   Setup a menu
         */
        void Setup();

        /**
         * @brief   Open a menu 
         */
        void Open();

        /**
         * @brief   Close the active menu 
         */
        void Close();
    }
}