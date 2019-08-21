/**
 * @file       : IPlayer.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public interface IPlayer : IHealable, IDamageable, IMovement, IEntity {

    }
}