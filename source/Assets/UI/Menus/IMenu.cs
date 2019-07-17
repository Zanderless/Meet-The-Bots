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
        void construct();

        /**
         * @brief   setup a menu
         */
        void setup();

        /**
         * @brief   open a menu 
         */
        void open();

        /**
         * @brief   close the active menu 
         */
        void close();
    }
}