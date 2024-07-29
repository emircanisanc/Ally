using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventoryManager : Singleton<WeaponInventoryManager>
{
    [SerializeField] private GameObject btnStartGame;
    [SerializeField] private Button btnShowNextWeap;
    [SerializeField] private Button btnShowPrevWeap;
    [SerializeField] private PlayerWeaponManager _playerWeaponManager;
    [SerializeField] private WeaponListSO _weaponList;
    [SerializeField] private Transform _weaponSpawnPoint;
    public WeaponSO CurrentSeenWeapon { get; set; } 
    public Action<WeaponSO> OnSeenWeaponChanged;
    public GameObject CurrentWeapon { get; private set; }
    private int _currentSeenWeaponIndex;
    /* private int _currentSelectedWeaponIndex; */

    public bool TryNewWeaponUnlock(int level)
    {
        bool canUnlock = _weaponList.Weapons.Count > level;
        if (canUnlock)
        {
            _weaponList.Weapons[level].Unlock();
        }
        return canUnlock;
    }
    public bool TryGetWeaponAt(int level, out WeaponSO weapon)
    {
        weapon = null;
        if (_weaponList.Weapons.Count <= level) return false;
        weapon = _weaponList.Weapons[level];
        return true;
    }

    protected override void Awake()
    {
        base.Awake();
        _currentSeenWeaponIndex = 0;
        _playerWeaponManager.CurrentWeaponData = _weaponList.Weapons[_currentSeenWeaponIndex];
        CurrentSeenWeapon = _playerWeaponManager.CurrentWeaponData;
        CurrentWeapon = Instantiate(CurrentSeenWeapon.WeaponPF, _weaponSpawnPoint);

        btnShowNextWeap.gameObject.SetActive(_currentSeenWeaponIndex != _weaponList.Weapons.Count - 1);
        btnShowPrevWeap.gameObject.SetActive(_currentSeenWeaponIndex != 0);
        btnShowNextWeap.onClick.AddListener(ShowNextWeapon);
        btnShowPrevWeap.onClick.AddListener(ShowPreviousWeapon);
    }

    public void ShowNextWeapon()
    {
        Destroy(CurrentWeapon);
        _currentSeenWeaponIndex++;
        _playerWeaponManager.CurrentWeaponData = _weaponList.Weapons[_currentSeenWeaponIndex];
        CurrentSeenWeapon = _playerWeaponManager.CurrentWeaponData;
        CurrentWeapon = Instantiate(CurrentSeenWeapon.WeaponPF, _weaponSpawnPoint);
        btnStartGame.SetActive(CurrentSeenWeapon.IsUnlocked);
        OnSeenWeaponChanged?.Invoke(CurrentSeenWeapon);

        btnShowNextWeap.gameObject.SetActive(_currentSeenWeaponIndex != _weaponList.Weapons.Count - 1);
        btnShowPrevWeap.gameObject.SetActive(true);
    }

    public void ShowPreviousWeapon()
    {
        Destroy(CurrentWeapon);
        _currentSeenWeaponIndex--;
        _playerWeaponManager.CurrentWeaponData = _weaponList.Weapons[_currentSeenWeaponIndex];
        CurrentSeenWeapon = _playerWeaponManager.CurrentWeaponData;
        CurrentWeapon = Instantiate(CurrentSeenWeapon.WeaponPF, _weaponSpawnPoint);
        btnStartGame.SetActive(CurrentSeenWeapon.IsUnlocked);
        OnSeenWeaponChanged?.Invoke(CurrentSeenWeapon);

        btnShowPrevWeap.gameObject.SetActive(_currentSeenWeaponIndex != 0);
        btnShowNextWeap.gameObject.SetActive(true);
    }

}
