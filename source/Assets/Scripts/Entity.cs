/**
 * @file       : Entity.cs
 * @author     :
 * @description:
 * @note    
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Attributes
{
    public readonly double heatlh;
    public readonly decimal stamina;
    public readonly decimal pysche;

    public MyStruct(double health, decimal stamina, decimal pysche)
    {
        this.health = health;
        this.stamina = stamina;
        this.pysche = pysche;
    }
}


public class Entity : MonoBehaviour
{
  
    /* Personality */
    


    /* Attributes */
    private Attributes attributes;

    public attributes Attributes
    {
        get { return attributes; }
        set { attributes = attributesData; }
    }

    // private float _health;
    // private float _stamina;
    // private float _psyche;

    public float maxHealth;
    public float maxStamina; 
    
    public float maxPsyche;
    
    private float _armor;

    public float maxArmor;


    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            _health = Mathf.Clamp(_health, 0, maxHealth);

            if (Health < 0)
                Die();
        }
    }

    public float Armor
    {
        get { return _armor; }
        set
        {
            _armor = value;
            _armor = Mathf.Clamp(_armor, 0, maxArmor);
        }
    }

    public bool IsAlive => Health > 0;

    /* Entity Pose */
    public Vector3 EnityPos => transform.position;
    public Quaternion EntityRot => transform.rotation;

    /* Life states */
    public virtual void Die()
    {
        print("dead");
    }

    public virtual void Fatigue()
    {
        print("fatigued");
    }


    public Entity()
    {
        attributes = new Attributes(maxHealth, maxStamina, maxPsyche);
    }

}
