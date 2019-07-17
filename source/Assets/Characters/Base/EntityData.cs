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

    namespace EntityData {
        /* Enitity Constants */
        public readonly decimal GRAVITY = 9.8m;

        /* Entity enum types */
        public enum LifeState {
            DEAD,
            ALIVE, 
            FATIGUED,
            STASIS,
        }
        
        /* Entity data structs */
        /**
         * @brief       entity attributes data struct 
         */
        public struct Attributes {
            /* Data values */
            public decimal fluid;
            public decimal energy;
            public decimal pysche;

            /* Upper bounds */
            public readonly decimal maxFluid; 
            public readonly decimal maxEnergy; 
            public readonly decimal maxPsyche; 

            /**
             * @brief   Constructor
             * @param   fluid       entity life fluid
             * @param   energy      entity life energy 
             * @param   psyche      entity mental energy   
             */
            public Attributes(decimal fluid, decimal energy, decimal pysche) {
                this.fluid = fluid;
                this.energy = energy;
                this.pysche = pysche;
            }
        }

        /**
         * @brief       entity abilities data struct 
         */
        public struct Abilities {
            /* Data values */
            public decimal plasma;
            public decimal gas;
            public decimal liquid;
            public decimal solid;

            /**
             * @brief   Constructor
             * @param   plasma      ...
             * @param   gas         ...
             * @param   liquid      ...
             * @param   solid       ...
             */
            public Abilities(decimal plasma, decimal gas, decimal liquid, decimal solid) {
                this.plasma = plasma;
                this.gas = gas;
                this.liquid = liquid; 
                this.solid = solid;
            }
        }

        /**
         * @brief       entity skills data struct 
         */
        public struct Skills {
            /* Data values */
            public decimal armor; 
            
            public decimal technology;

            /**
             * @brief   Constructor
             */
            public Skills(decimal armor, decimal technology) {
                this.armor = armor; 
                this.technology = technology;
            } 
        }

        /**
         * @brief       entity physics data struct 
         */
        public struct Physics {
            /* Data values */
            public decimal gravity; 
            public decimal position;
            public decimal speed;
            public decimal acceleration;
            
            /**
             * @brief   Constructor
             * @param   gravity         ...
             * @param   position        ...
             * @param   speed           ...
             * @param   acceleration    ...
             */
            public Physics(decimal gravity, decimal position, decimal speed, decimal acceleration) {
                this.gravity = gravity; 
                this.position = position;
                this.speed = speed; 
                this.acceleration = acceleration;
            } 
        }        
    }
}