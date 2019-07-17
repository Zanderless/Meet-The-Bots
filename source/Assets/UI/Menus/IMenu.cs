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
         * @brief   construct a new menu 
         */
        void Construct();

        /**
         * @brief   setup a menu
         */
        void Setup();

        /**
         * @brief   open a menu 
         */
        void Open();

        /**
         * @brief   close the active menu 
         */
        void Close();
    }
}