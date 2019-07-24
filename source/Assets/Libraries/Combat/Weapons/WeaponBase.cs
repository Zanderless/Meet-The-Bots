/**
 * @file       : Entity.cs
 * @author     : Jakob P.
 * @description: The script that handles all weapon logic
 * @note       : This script belongs on the actual gun/fps arms prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    
    

}

public class WeaponInfo
{

    public float MaxAmmo { get; set; }
    public float MaxStoredAmmo { get; set; }
    public float FireRate { get; set; }
    public decimal Damage { get; set; }
    public float ShotDistance { get; set; }
    public string WeaponPrefab { get; set; }
    public bool IsAutomatic { get; set; }
    public bool UsesAmmo { get; set; }
    public bool UsesProjectile { get; set; }
    public string ProjectilePrefab { get; set; }

}
