﻿/**
 * @file       : Entity.cs
 * @author     :
 * @description:
 * @note    
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EntityData;

namespace MTB {

    public class Entity : MonoBehaviour {
        /* Entity Data */
        private Attributes _attributes;

        public Attributes Attributes  {
            get { return _attributes; }
            set { attributes = _attribute; }
        }

        /**
         * @brief   Constructor
         */
        public Entity() {
            attributes = new Attributes(maxHealth, maxStamina, maxPsyche);
        }
    }
}