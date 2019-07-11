/**
 * @file       : IMenu.cs
 * @author     :
 * @description: Menu Interface
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMenu {
    void construct();
    void setup();
    void open();
    void close();
}