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
        private EntityData.Attributes _attributes;

        public EntityData.Attributes Attributes  {
            get { return _attributes; }
            set { _attribute = value; }
        }

        /**
         * @brief   Constructor
         */
        public Entity() {
            _attributes = new Attributes(EntityData.maxHealth, 
                                         EntityData.maxStamina, 
                                         EntityData.maxPsyche);
        }
    }
}