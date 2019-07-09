/**
 * @file       : BaseItem.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{

    // resource that item provides 
    [Tooltip("")]
    public float resource;

    /**
     * @brief   when item has triggered an event
     * @param   other       object which has triggered item event      
     */
    private void OnTriggerEnter(Collider other) {

    }
}
