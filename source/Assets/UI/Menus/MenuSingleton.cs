/**
 * @file       : MenuSingleton.cs
 * @author     :
 * @description: Menu Singleton (Thread Safe)
 * @note    https://csharpindepth.com/articles/singleton
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {
        
    public sealed class MenuSingleton {
        private static MenuSingleton instance = null;
        private static readonly object padlock = new object();

        /**
         * @brief   constructor
         */
        MenuSingleton()
        {}

        /**
         * @brief   singleton instance
         */
        public static MenuSingleton Instance {
            get {
                lock (padlock) {
                if (instance == null) {
                    instance = new MenuSingleton();
                }
                    return instance;
                }
            }
        }
    }
}