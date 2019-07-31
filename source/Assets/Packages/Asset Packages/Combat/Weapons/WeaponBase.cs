/**
 * @file       : WeaponBase.cs
 * @author     : Jakob P.
 * @description: The script that handles all weapon logic
 * @note       : This script belongs on the actual gun/fps arms prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB
{
    public abstract class WeaponBase : MonoBehaviour
    {

        //Public Variables
        public WeaponInfo info;

        //Private Variables
        private int ammo;
        private int storedAmmo;

        #region Private Methods

        private void Start()
        {

            ammo = info.maxAmmo;
            storedAmmo = info.maxStoredAmmo;
        }

        private void Update()
        {
            
            if(Input.GetAxisRaw("Fire") == 1 && ammo > 0)
            {
                Fire();
            }

            if(ammo < info.maxAmmo && storedAmmo > 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                    Reload();
            }

        }

        private void OnGUI()
        {

            GUI.Box(new Rect(0, 0, 100, 20), ammo + "/" + storedAmmo);

        }

        #endregion

        #region Public Methods

        public int Ammo
        {
            get { return ammo; }
            set
            {
                ammo = value;
                ammo = Mathf.Clamp(ammo, 0, info.maxAmmo);
            }
        }

        public int StoredAmmo
        {
            get { return storedAmmo; }
            set
            {
                storedAmmo = value;
                storedAmmo = Mathf.Clamp(storedAmmo, 0, info.maxStoredAmmo);
            }
        }

        public virtual void Fire()
        {

            if (info.usesAmmo)
                ammo--;

            if(!info.usesProjectile)
                RayCast();

        }

        public virtual void RayCast()
        {

            RaycastHit hit;

            if(UnityEngine.Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, info.shotDistance))
            {

                if (hit.transform.GetComponent<Entity>())
                {

                    float modifiedDamage = info.damage * info.damageFalloff.Evaluate(hit.distance / info.shotDistance);

                    print(modifiedDamage);

                }

            }

        }

        public virtual void Reload()
        {

            if (storedAmmo >= ammo)
            {
                storedAmmo -= (info.maxAmmo - ammo);
                ammo = info.maxAmmo;
            }
            else if (storedAmmo < ammo)
            {
                int ammoDiff = info.maxAmmo - ammo;
                if (ammoDiff >= storedAmmo)
                {
                    ammo += (ammoDiff - storedAmmo);
                    storedAmmo = 0;
                }
                else if (ammoDiff < storedAmmo)
                {
                    ammo = info.maxAmmo;
                    storedAmmo -= (storedAmmo - ammoDiff);
                }
            }
        }

        #endregion

    }

    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 0)]
    public class WeaponInfo : ScriptableObject
    {
        public string weaponName;
        public int maxAmmo;
        public int maxStoredAmmo;
        public float fireRate;
        public float damage;
        public AnimationCurve damageFalloff;
        public float shotDistance;
        public string weaponPrefab;
        public bool isAutomatic;
        public bool usesAmmo;
        public bool usesProjectile;
        public GameObject projectilePrefab;
        public enum ReloadType
        {
            Clip,
            Shell
        }
        public ReloadType reloadType;

    }
}