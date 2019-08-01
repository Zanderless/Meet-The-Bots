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
        private float ammo;
        private float storedAmmo;

        private Vector3 recoilSmoothDampVelocity;
        private float recoilRotSmoothDampVelocity;
        private float recoilAngle;

        private float nextShotTime;
        private int shotsLeftInBurst;

        private bool isReloading;
        private bool triggeReleasedFromLastFire;
        #endregion

        #region Private Methods

        void Start()
        {
            shotsLeftInBurst = weaponInfo.burstAmmont;
            source = GetComponent<AudioSource>();
        }

        void LateUpdate()
        {
            ResetRecoil();
        }

        private void ResetRecoil()
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, Vector3.zero, ref recoilSmoothDampVelocity, weaponInfo.recoilMoveSettleTime);

            if (!isReloading)
            {
                recoilAngle = Mathf.SmoothDamp(recoilAngle, 0, ref recoilRotSmoothDampVelocity, recoilRotSmoothDampVelocity);
                transform.localEulerAngles = Vector3.left * recoilAngle;
            }
        }

        protected void Recoil()
        {
            transform.localPosition -= Vector3.forward * Random.Range(weaponInfo.kickMinMax.x, weaponInfo.kickMinMax.y);
            recoilAngle += Random.Range(weaponInfo.recoilAngleMinMax.x, weaponInfo.recoilAngleMinMax.y);
            recoilAngle = Mathf.Clamp(recoilAngle, 0, 30);
        }

        #endregion

        #region Public Methods

        public virtual void Fire()
        {

            if(!isReloading && Time.time > nextShotTime && ammo > 0)
            {

                if (weaponInfo.fireMode == WeaponInfo.FireMode.Burst)
                {
                    if (shotsLeftInBurst == 0)
                        return;
                    shotsLeftInBurst--;
                }
                else if (weaponInfo.fireMode == WeaponInfo.FireMode.Single)
                    if (!triggeReleasedFromLastFire) return;

            }

            nextShotTime = Time.time + weaponInfo.fireRate;

            ammo--;

            if (!weaponInfo.usesProjectile)
                RaycastShot();

            Recoil();

            source.PlayOneShot(weaponInfo.shootAudio, 1);

        }

        public virtual void RaycastShot()
        {

            print("Fire");

        }

        public virtual void ProjectileShot()
        {

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