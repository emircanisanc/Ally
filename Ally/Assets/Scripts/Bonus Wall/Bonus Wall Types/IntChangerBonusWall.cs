using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntChangerBonusWall : BaseBonusWall
{
    [SerializeField] protected int changeValueMin;
    [SerializeField] protected int changeValueMax;
    [SerializeField] protected int changeValueMultiplier;
    protected int changeValueOnHit;
    [SerializeField] protected TextMeshPro changeValueTMP;
    [SerializeField] protected int currentValueMin;
    [SerializeField] protected int currentValueMax;
    [SerializeField] protected int currentValueMultiplier;
    protected int currentValue;
    [SerializeField] protected TextMeshPro currentValueTMP;
    [SerializeField] protected Material wallMaterial;
    [SerializeField] protected Float variableToChange;

    private void Start()
    {
        changeValueOnHit = Random.Range(changeValueMin, changeValueMax) * changeValueMultiplier;
        currentValue = Random.Range(currentValueMin, currentValueMax) * currentValueMultiplier;

        changeValueTMP.SetText(changeValueOnHit.ToString());

        UpdateCurrentTMP();
    }

    protected void UpdateCurrentTMP()
    {
        currentValueTMP.text = currentValue.ToString();
    }

    public void ApplyDamage(float damage)
    {
        currentValue += changeValueOnHit;
        UpdateCurrentTMP();
    }

    protected override void OnPlayerEnter()
    {
        variableToChange.Value += (currentValue / 100f);
    }

}
