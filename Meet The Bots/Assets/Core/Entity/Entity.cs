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

using MTB;

namespace MTB {

    public class Entity : MonoBehaviour {

        /* Entity Data */
        private Attributes _attributes;

        public Attributes Attributes  
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        /**
         * @brief   Constructor
         */
        public Entity() {
            _attributes = new Attributes(EntityData.maxFluid, 
                                         EntityData.maxEnergy, 
                                         EntityData.maxPsyche,
                                         EntityData.maxStability);
        }
    }
}