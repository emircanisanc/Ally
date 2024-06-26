using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon Data")]
public class WeaponSO : ScriptableObject
{
    public string WeaponName;
    public Sprite WeaponSprite;
    public float WeaponBaseDamage;
    public float WeaponBaseRange;
    public float WeaponBaseAttackRate;
    public GameObject WeaponPF;
    public WeaponUpgradeData WeaponUpgradeData;
    [SerializeField] protected int weaponExtraDamageMultiplier;
    [SerializeField] protected int weaponExtraRateMultiplier;
    [SerializeField] protected int weaponExtraRangeMultiplier;

    public bool IsUnlocked => true;

    public int WeaponExtraAttackRate => weaponExtraRangeMultiplier * WeaponUpgradeData.WeaponExtraRateLevel / 100;
    public int WeaponExtraDamage => weaponExtraDamageMultiplier * WeaponUpgradeData.WeaponExtraDamageLevel / 100;
    public int WeaponExtraRange => weaponExtraRangeMultiplier * WeaponUpgradeData.WeaponExtraRangeLevel / 100;

    private void OnEnable()
    {
        WeaponUpgradeData = new WeaponUpgradeData(WeaponName);
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

    }

    public void Load()
    {

    }
}
