using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB
{
    public class WeaponManager : MonoBehaviour
    {

        public WeaponBase weapon;

        private void Update()
        {
            if (Input.GetAxisRaw("Fire") == 1)
                weapon.TriggerDown();
            else if(Input.GetAxisRaw("Fire") == 0)
                weapon.TriggerUp();

            if (Input.GetKeyDown(KeyCode.R))
                weapon.Reload();
        }

    }
}
