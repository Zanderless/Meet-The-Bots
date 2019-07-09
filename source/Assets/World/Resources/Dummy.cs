/**
 * @file       : Dummy.cs
 * @author     :
 * @description:
 * @note    
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }
}
