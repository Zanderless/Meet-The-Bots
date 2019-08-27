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
        public static readonly decimal maxFluid;
        public static readonly decimal maxEnergy;
        public static readonly decimal maxPsyche;
        public static readonly decimal maxStability;
    }

    public class InputData {
        public static readonly String HORIZONTAL = "horizontal";
        public static readonly String VERTICAL = "vertical";
        public static readonly String JUMP = "jump";
    }

    public class PhysicsData
    {
        public static readonly float GRAVITY = 9.8f;
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
        public Attributes(decimal fluid, decimal energy, decimal pysche, decimal stability)
        {
            this.fluid = fluid;
            this.energy = energy;
            this.pysche = pysche;
            this.stability = stability;
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