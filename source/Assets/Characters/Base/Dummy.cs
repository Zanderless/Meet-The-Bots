/**
 * @file       : Dummy.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public class Dummy : Entity, IEntity {

        Entity E => new Entity();

        /** 
* @brief   Start is called before the first frame update
*/
        void Start() {

            print(E.Attributes.fluid);

        }

        public void Die()
        {
            this.gameObject.SetActive(false);
        }
    }
}