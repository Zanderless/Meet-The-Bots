/**
 * @file       : Entity.cs
 * @author     : Jakob P.
 * @description: The script that handles all weapon logic
 * @note       : This script belongs on the actual gun/fps arms prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB
{
    public class WeaponBase : MonoBehaviour
    {

        //Public Variables
        [Tooltip("Insert path to weapon json file. Don't include Assets or Resources folder \n EX. Weapon/Data/Pistol")]
        public string dataPath;

        //Private Variables
        private WeaponInfo info;
        private int ammo;
        private int storedAmmo;

        #region Private Methods

        private void Start()
        {
            info = Json.LoadData<WeaponInfo>(dataPath);

            ammo = info.MaxAmmo;
            storedAmmo = info.MaxStoredAmmo;
        }

        private void Update()
        {
            
            if(Input.GetAxisRaw("Fire") == 1 && ammo > 0)
            {
                Fire();
            }

            if(ammo < info.MaxAmmo && storedAmmo > 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                    Reload();
            }

        }

        private void Fire()
        {

            if (info.UsesAmmo)
                ammo--;

        }

        private void Reload()
        {

            if (storedAmmo >= ammo)
            {
                int t = info.MaxAmmo - ammo;
                storedAmmo -= t;
                ammo = info.MaxAmmo;
            }
            else if (storedAmmo < ammo)
            {
                int amo = info.MaxAmmo - ammo;
                if(amo >= storedAmmo)
                {
                    int t = amo - storedAmmo;
                    ammo += t;
                    storedAmmo = 0;
                }
                else if(amo < storedAmmo)
                {
                    int t = storedAmmo - amo;
                    ammo = info.MaxAmmo;
                    storedAmmo -= t;
                }
            }
        }

        private void OnGUI()
        {

            GUI.Box(new Rect(0, 0, 100, 20), ammo + "/" + storedAmmo);

        }

        #endregion

    }

    [System.Serializable]
    public class WeaponInfo
    {
        public string WeaponName;
        public int MaxAmmo;
        public int MaxStoredAmmo;
        public float FireRate;
        public float Damage;
        public float ShotDistance;
        public string WeaponPrefab;
        public bool IsAutomatic;
        public bool UsesAmmo;
        public bool UsesProjectile;
        public string ProjectilePrefab;

    }
}