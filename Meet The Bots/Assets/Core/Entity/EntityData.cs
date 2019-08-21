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

namespace MTB
{

    // /* Enitity Constants */
    // public readonly decimal GRAVITY = 9.8;

    public class EntityData
    {
<<<<<<< HEAD
        public static readonly decimal maxFluid = 100;
        public static readonly decimal maxEnergy;
        public static readonly decimal maxPsyche;

=======
        public readonly decimal maxFluid;
        public readonly decimal maxEnergy;
        public readonly decimal maxPsyche;
        public readonly decimal maxStability;
    }

    public class InputData {
        public readonly String HORIZONTAL = "horizontal";
        public readonly String VERTICAL = "vertical";
        public readonly String JUMP = "horizontal";
    }

    public class PhysicsData {
        public readonly decimal GRAVITY = 9.8;
>>>>>>> initial API
    }

    /* Entity enum types */
    public enum LifeState
    {
        DEAD,
        ALIVE,
        FATIGUED,
        STASIS,
    }

    /* Entity data structs */
    /**
     * @brief       Entity attributes data struct 
     */
    public struct Attributes
    {
        /* Data values */
        public decimal fluid;
        public decimal energy;
        public decimal pysche;
        public decimal stability; 

        /**
         * @brief   Constructor
         * @param   fluid       Entity life fluid
         * @param   energy      Entity life energy 
         * @param   psyche      Entity mental energy   
         */
        public Attributes(decimal fluid, decimal energy, decimal pysche)
        {
            this.fluid = fluid;
            this.energy = energy;
            this.pysche = pysche;
        }
    }

    /**
     * @brief       Entity abilities data struct 
     */
    public struct Abilities
    {
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
        public Abilities(decimal plasma, decimal gas, decimal liquid, decimal solid)
        {
            this.plasma = plasma;
            this.gas = gas;
            this.liquid = liquid;
            this.solid = solid;
        }
    }

    /**
     * @brief       Entity skills data struct 
     */
    public struct Skills
    {
        /* Data values */
        public decimal armor;

        public decimal technology;

        /**
         * @brief   Constructor
         */
        public Skills(decimal armor, decimal technology)
        {
            this.armor = armor;
            this.technology = technology;
        }
    }

    /**
     * @brief       Entity physics data struct 
     */
    public struct Physics
    {
        /* Data values */
        public decimal mass;
        public decimal position;
        public decimal speed;
        public decimal acceleration;

        /**
         * @brief   Constructor
         * @param   mass         ...
         * @param   position        ...
         * @param   speed           ...
         * @param   acceleration    ...
         */
        public Physics(decimal mass, decimal position, decimal speed, decimal acceleration)
        {
            this.mass = mass;
            this.position = position;
            this.speed = speed;
            this.acceleration = acceleration;
        }
    }
}