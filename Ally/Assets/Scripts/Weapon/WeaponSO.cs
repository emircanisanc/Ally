using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon Data")]
public class WeaponSO : ScriptableObject
{
    public int WeaponId;
    public string WeaponName;
    public Sprite WeaponSprite;
    public float WeaponBaseDamage;
    public float WeaponBaseRange;
    public float WeaponBaseAttackRate;
    public GameObject WeaponPF;
    public GameObject WeaponVisualPF;
    public WeaponUpgradeData WeaponUpgradeData;
    [SerializeField] protected int weaponExtraDamageMultiplier;
    [SerializeField] protected int weaponExtraRateMultiplier;
    [SerializeField] protected int weaponExtraRangeMultiplier;

    public bool IsUnlocked => WeaponId == 0 || PlayerPrefs.GetInt("isUnlockedWep" + WeaponId, 0) == 1;
    public void Unlock()
    {
        PlayerPrefs.SetInt("isUnlockedWep" + WeaponId, 1);
    }

    public int WeaponExtraAttackRate => weaponExtraRangeMultiplier * WeaponUpgradeData.WeaponExtraRateLevel / 100;
    public int WeaponExtraDamage => weaponExtraDamageMultiplier * WeaponUpgradeData.WeaponExtraDamageLevel / 100;
    public int WeaponExtraRange => weaponExtraRangeMultiplier * WeaponUpgradeData.WeaponExtraRangeLevel / 100;

    private void OnEnable()
    {
        WeaponUpgradeData = new WeaponUpgradeData(WeaponId.ToString());
    }
}

public class WeaponUpgradeData
{
    public WeaponUpgradeData(string weaponName)
    {
        WeaponName = weaponName;
        Load();
    }
    public string WeaponName;
    private int _damageLevel;
    public int WeaponExtraDamageLevel { get { return _damageLevel; } set { _damageLevel = value; Save(); } }
    private int _rateLevel;
    public int WeaponExtraRateLevel { get { return _rateLevel; } set { _rateLevel = value; Save(); } }
    private int _rangeLevel;
    public int WeaponExtraRangeLevel { get { return _rangeLevel; } set { _rangeLevel = value; Save(); } }

    public void Save()
    {
        PlayerPrefs.SetInt(WeaponName + "damageLevel", _damageLevel);
        PlayerPrefs.SetInt(WeaponName + "rateLevel", _rateLevel);
        PlayerPrefs.SetInt(WeaponName + "rangeLevel", _rangeLevel);
    }

    public void Load()
    {
        _damageLevel = PlayerPrefs.GetInt(WeaponName + "damageLevel", 0);
        _rateLevel = PlayerPrefs.GetInt(WeaponName + "rateLevel", 0);
        _rangeLevel = PlayerPrefs.GetInt(WeaponName + "rangeLevel", 0);
    }
}
