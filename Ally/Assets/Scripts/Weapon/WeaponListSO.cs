using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponList")]
public class WeaponListSO : ScriptableObject
{
    public List<WeaponSO> Weapons;
}
