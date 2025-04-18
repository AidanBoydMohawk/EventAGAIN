using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Fire, Ice, Normal, Lightning, Dark}
[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ItemSO
{
    public float minDamage = 1;
    public float maxDamage = 10;
    public DamageType damageType = DamageType.Normal;
}
