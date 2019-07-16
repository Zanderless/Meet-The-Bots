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
        static const double GRAVITY = 9.8f;

        /* Entity enum types */
        public static enum LifeState {
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
            public double fluid;

            public decimal energy;

            public decimal pysche;

            /* Upper bounds */
            public readonly double maxHealth; 

            public readonly double maxStamina; 
            
            public readonly double maxPsyche; 

            /**
             * @brief   Constructor
             * @param   fluid       entity life fluid
             * @param   energy      entity life energy 
             * @param   psyche      entity mental energy   
             */
            public Attributes(double health, decimal stamina, decimal pysche) {
                this.health = health;
                this.stamina = stamina;
                this.pysche = pysche;
            }
        }

        /**
         * @brief       entity abilities data struct 
         */
        public struct Abilities {
            /* Data values */
            public double plasma;

            public double gas;

            public double liquid;

            public double solid;

            /**
             * @brief   Constructor
             * @param   plasma      ...
             * @param   gas         ...
             * @param   liquid      ...
             * @param   solid       ...
             */
            public Abilities(double plasma, double gas, double liquid, double solid) {
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
            public double armor; 
            
            public double technology;

            /**
             * @brief   Constructor
             */
            public Skills(double armor, dobule technology) {
                this.armor = armor; 
                this.technology = technology;
            } 
        }

        /**
         * @brief       entity physics data struct 
         */
        public struct Physics {
            /* Data values */
            public double gravity; 
            public double position;
            public double speed;
            public double acceleration;
            
            /**
             * @brief   Constructor
             * @param   gravity         ...
             * @param   position        ...
             * @param   speed           ...
             * @param   acceleration    ...
             */
            public Physics(double gravity, double position, double speed, double acceleration) {
                this.gravity = gravity; 
                this.position = position;
                this.speed = speed; 
                this.acceleration = acceleration;
            } 
        }        
    }
}