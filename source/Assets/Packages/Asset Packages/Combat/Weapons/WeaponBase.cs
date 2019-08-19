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
        private bool triggerReleasedFromLastFire;

        private Transform pCam;
        private RaycastHit hit;
        #endregion

        #region Private Methods

        void Awake()
        {
            shotsLeftInBurst = weaponInfo.burstAmmont;
            source = GetComponent<AudioSource>();
            ammo = weaponInfo.maxAmmo;
            storedAmmo = weaponInfo.maxStoredAmmo;
            triggerReleasedFromLastFire = true;
            pCam = transform.parent;
        }

        /** 
        * @brief   Returns bool if the raycast collides with a object or not
        */
        private bool RayCast()
        {
            return UnityEngine.Physics.Raycast(pCam.position, pCam.forward + weaponInaccuracy(weaponInfo.maxInaccurecy, weaponInfo.minInaccuracy), out hit, weaponInfo.shotDistance);
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(0, 0, 100, 20), ammo + "/" + storedAmmo);
        }

        #endregion

        #region Public Methods


        /** 
        * @brief   Firing logic
        */
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
                    if (!triggerReleasedFromLastFire)
                        return;

                nextShotTime = Time.time + weaponInfo.fireRate;

                ammo--;

                if (!weaponInfo.usesProjectile)
                    RaycastShot();

                source.PlayOneShot(weaponInfo.shootAudio, 1);

                triggerReleasedFromLastFire = false;

            }

        }

        /** 
        * @brief   Logic for Raycast shooting
        */
        public virtual void RaycastShot()
        {

            if(RayCast())
            {
                Entity entity = hit.transform.GetComponent<Entity>();

                if (entity && entity is IDamageable)
                {
                    var damageable = entity as IDamageable;
                    if (damageable != null)
                    {
                        float adjustedDmg = weaponInfo.damage * weaponInfo.damageFalloff.Evaluate(hit.distance / weaponInfo.shotDistance);
                        damageable.TakeDamage(new DamageInfo(adjustedDmg, null, Vector3.zero));
                    }
                }
            }
        }

        /** 
        * @brief   Logic for Projectile shooting
        */
        public virtual void ProjectileShot()
        {

        }

        /** 
        * @brief   Weapon Reloading
        */
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
                int ammoDiff = weaponInfo.maxAmmo - ammo;
                if (ammoDiff >= storedAmmo)
                {
                    int t = ammoDiff - storedAmmo;
                    ammo += t;
                    storedAmmo = 0;
                }
                else if (ammoDiff < storedAmmo)
                {
                    int t = storedAmmo - ammoDiff;
                    ammo = weaponInfo.maxAmmo;
                    storedAmmo -= t;
                }
            }
        }

        public Vector3 weaponInaccuracy(Vector2 max, Vector2 min)
        {

            float x = Random.Range(min.x, max.x);
            float y = Random.Range(min.y, max.y);

            Vector3 inaccuracy = new Vector3(x, y, 0);
            inaccuracy = transform.TransformDirection(inaccuracy);
            return inaccuracy;

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
            triggerReleasedFromLastFire = true;
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

        [Header("Weapon Inaccuracy")]
        public Vector2 minInaccuracy;
        public Vector2 maxInaccurecy;

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

    public class DamageInfo
    {

        private float damage;
        private Player player;
        private Vector3 origin;

        public DamageInfo(float dmg, Player player, Vector3 origin)
        {
            damage = dmg;
            this.player = player;
            this.origin = origin;
        }

        public float GetDamage()
        {
            return damage;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Vector3 GetOrigin()
        {
            return origin;
        }
    }

}