using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventoryManager : Singleton<WeaponInventoryManager>
{
    [SerializeField] private PlayerWeaponManager _playerWeaponManager;
    [SerializeField] private WeaponListSO _weaponList;
    [SerializeField] private Transform _weaponSpawnPoint;
    public WeaponSO CurrentSeenWeapon { get; set; } 
    public Action<WeaponSO> OnSeenWeaponChanged;
    public GameObject CurrentWeapon { get; private set; }
    private int _currentSeenWeaponIndex;
    private int _currentSelectedWeaponIndex;

    protected override void Awake()
    {
        base.Awake();
        _currentSeenWeaponIndex = 0;
        _currentSelectedWeaponIndex = _currentSeenWeaponIndex;
        _playerWeaponManager.CurrentWeaponData = _weaponList.Weapons[_currentSelectedWeaponIndex];
        CurrentSeenWeapon = _playerWeaponManager.CurrentWeaponData;
        CurrentWeapon = Instantiate(CurrentSeenWeapon.WeaponPF, _weaponSpawnPoint);
    }

    public void ShowNextWeapon()
    {

    }

    public void ShowPreviousWeapon()
    {

    }

}
