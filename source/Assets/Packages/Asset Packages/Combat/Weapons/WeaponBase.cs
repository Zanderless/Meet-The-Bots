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

        #region Public Variables
        public WeaponInfo weaponInfo;
        public AudioSource source;
        #endregion

        #region Private Variables
        private int ammo;
        private int storedAmmo;

        private Vector3 recoilSmoothDampVelocity;
        private float recoilRotSmoothDampVelocity;
        private float recoilAngle;

        private float nextShotTime;
        private int shotsLeftInBurst;

        private bool isReloading;
        private bool triggeReleasedFromLastFire;

        private Transform pCam;
        #endregion

        #region Private Methods

        void Awake()
        {
            shotsLeftInBurst = weaponInfo.burstAmmont;
            source = GetComponent<AudioSource>();
            ammo = weaponInfo.maxAmmo;
            storedAmmo = weaponInfo.maxStoredAmmo;
            triggeReleasedFromLastFire = true;
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(0, 0, 100, 20), ammo + "/" + storedAmmo);
        }

        #endregion

        #region Public Methods

        public virtual void Fire()
        {

            if (!isReloading && Time.time > nextShotTime && ammo > 0)
            {

                if (weaponInfo.fireMode == WeaponInfo.FireMode.Burst)
                {
                    if (shotsLeftInBurst == 0)
                        return;
                    shotsLeftInBurst--;
                }
                else if (weaponInfo.fireMode == WeaponInfo.FireMode.Single)
                    if (!triggeReleasedFromLastFire) return;

                nextShotTime = Time.time + weaponInfo.fireRate;

                ammo--;

                if (!weaponInfo.usesProjectile)
                    RaycastShot();

                //source.PlayOneShot(weaponInfo.shootAudio, 1);

                triggeReleasedFromLastFire = false;

            }

        }

        public virtual void RaycastShot()
        {

            print("Fire");

        }

        public virtual void ProjectileShot()
        {

        }

        public virtual void Reload()
        {
            if (storedAmmo >= ammo)
            {
                int t = weaponInfo.maxAmmo - ammo;
                storedAmmo -= t;
                ammo = weaponInfo.maxAmmo;
            }
            else if (storedAmmo < ammo)
            {
                int amo = weaponInfo.maxAmmo - ammo;
                if (amo >= storedAmmo)
                {
                    int t = amo - storedAmmo;
                    ammo += t;
                    storedAmmo = 0;
                }
                else if (amo < storedAmmo)
                {
                    int t = storedAmmo - amo;
                    ammo = weaponInfo.maxAmmo;
                    storedAmmo -= t;
                }
            }
        }

        public int Ammo
        {
            get { return ammo; }
            set
            {
                ammo = value;
                ammo = Mathf.Clamp(ammo, 0, weaponInfo.maxAmmo);
            }
        }

        public int StoredAmmo
        {
            get { return storedAmmo; }
            set
            {
                storedAmmo = value;
                storedAmmo = Mathf.Clamp(storedAmmo, 0, weaponInfo.maxStoredAmmo);
            }
        }

        public void TriggerDown()
        {
            Fire();
        }

        public void TriggerUp()
        {
            triggeReleasedFromLastFire = true;
            shotsLeftInBurst = weaponInfo.burstAmmont;
        }

        #endregion

    }

    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 0)]
    public class WeaponInfo : ScriptableObject
    {

        public enum FireMode
        {
            Single,
            Burst,
            Automatic
        }

        public enum RecoilMode
        {
            None,
            Low,
            Normal,
            High
        }

        public enum ReloadType
        {
            Clip,
            Single
        }

        [Header("Stats")]
        public string weaponName;
        public FireMode fireMode;
        public float fireRate;
        public int burstAmmont;
        public bool usesAmmo;
        public int maxAmmo;
        public int maxStoredAmmo;

        [Header("Reload")]
        public float reloadTime;
        public ReloadType reloadType;

        [Header("Projectile")]
        public bool usesProjectile;
        public GameObject projectile;
        public float projectileVelocity;

        [Header("Raycast")]
        public float shotDistance;

        [Header("Damage")]
        public float damage;
        public AnimationCurve damageFalloff;

        [Header("Recoil")]
        public Vector2 kickMinMax;
        public Vector2 recoilAngleMinMax;
        public float recoilMoveSettleTime;
        public float recoilRotationSettleTime;
        public RecoilMode recoilMode;

        [Header("Sounds")]
        public AudioClip shootAudio;
        public AudioClip reloadAudio;

    }
}