using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealable
{
    void AddHealth(float h);
    void AddArmor(float a);
}
