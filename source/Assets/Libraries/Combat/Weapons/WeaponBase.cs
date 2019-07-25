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

        //private variables
        private WeaponInfo info;

        private void Start()
        {
            LoadData();
        }

        void LoadData()
        {

            TextAsset text = Resources.Load(dataPath) as TextAsset;

            try
            {
                info = JsonUtility.FromJson<WeaponInfo>(text.text);
            }
            catch
            {
                Debug.LogError("Cannot find file from path");
            }

            print(info.WeaponName);

        }

    }

    [System.Serializable]
    public class WeaponInfo
    {
        public string WeaponName;
        public float MaxAmmo;
        public float MaxStoredAmmo;
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