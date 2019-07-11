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
    interface IManager {

        /**
        *
        */
        void load();

        void quit();

        void open();

        void close();

    }

}


