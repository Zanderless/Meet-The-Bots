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

namespace MTB {

    public class Entity : MonoBehaviour, IEntity {
    
        /* Personality */
        

        /* Attributes */
        private Attributes attributes;

        public attributes Attributes {
            get { return attributes; }
            set { attributes = attributesData; }
        }


        public Entity() {
            attributes = new Attributes(maxHealth, maxStamina, maxPsyche);
        }
    }
}