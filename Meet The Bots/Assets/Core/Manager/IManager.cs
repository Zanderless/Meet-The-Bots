/**
 * @file       : IManager.cs
 * @author     :
 * @description: Core Game manager
 * @note    
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {
    
    public interface IManager {

        /**
         *  @brief  Load an existing item 
         */
        void Load();

        /**
         *  @brief  Save the current active item
         */
        void Save();

        /**
         *  @brief  Destroy an exusting item
         */
        void Destroy();

        /**
         *  @brief  Create a new item
         */
        void Create();

    }
}


