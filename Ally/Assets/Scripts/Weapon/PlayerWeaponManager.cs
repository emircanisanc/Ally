using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponSO _currentWeaponData;
    public WeaponSO CurrentWeaponData { get { return _currentWeaponData;} set { _currentWeaponData = value;} }

    public float BaseWeaponAttackRange => _currentWeaponData.WeaponBaseRange + _currentWeaponData.WeaponExtraRange;
    public float BaseWeaponAttackDamage => _currentWeaponData.WeaponBaseDamage + _currentWeaponData.WeaponExtraDamage;
    public float BaseWeaponAttackRate => _currentWeaponData.WeaponBaseAttackRate + _currentWeaponData.WeaponExtraAttackRate;

    [SerializeField] private Float _weaponFinalDamage;
    [SerializeField] private Float _weaponFinalAttackRate;
    [SerializeField] private Float _weaponFinalRange;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += ResetWeaponStats;
        GameManager.Instance.OnGameStarted += SetWeapon;
        GameManager.Instance.OnGameEnd += ResetWeaponStats;
    }

    private void OnDisable()
    {
        if (!GameManager.Instance) return;
        GameManager.Instance.OnGameStarted -= SetWeapon;
        GameManager.Instance.OnGameStarted -= ResetWeaponStats;
        GameManager.Instance.OnGameEnd -= ResetWeaponStats;
    }

    public void SetWeapon()
    {
        CurrentWeaponData = WeaponInventoryManager.Instance.CurrentSeenWeapon;
    }

    public void ResetWeaponStats()
    {
        _weaponFinalAttackRate.Value = BaseWeaponAttackDamage;
        _weaponFinalDamage.Value = BaseWeaponAttackDamage;
        _weaponFinalRange.Value = BaseWeaponAttackRange;
    }
}
