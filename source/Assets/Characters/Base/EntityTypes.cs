/**
 * @file       : EntityTypes.cs
 * @author     :
 * @description:
 * @note    
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public struct Attributes {

        public readonly double maxHealth; 

        public readonly double maxStamina; 
        
        public readonly double maxPsyche; 
        
        public double heatlh;

        public decimal stamina;

        public decimal pysche;

        /**
         * @brief   constructor
         */
        public Attributes(double health, decimal stamina, decimal pysche) {
            this.health = health;
            this.stamina = stamina;
            this.pysche = pysche;
        }
    }

    public struct Abilities {
        public double plasma;

        public double gas;

        public double liquid;

        public double solid;

        /**
         * @brief   constructor
         */
        public Abilities(double plasma, double gas, double liquid, double plasma) {
            this.plasma = plasma;
            this.gas = gas;
            this.liquid = liquid; 
            this.solid = solid;
        }
    }

    public struct Skills {
        public double armor; 
        
        public double technology;

        /**
         * @brief   constructor
         */
        public Skills(double armor, dobule technology) {
            this.armor = armor; 
            this.technology = technology;
        } 
    }
}