using TMPro;
using UnityEngine;

public class FloatChangerBonusWall : BaseBonusWall, IDamageable
{
    [SerializeField] protected float changeValueOnHitMin;
    [SerializeField] protected float changeValueOnHitMax;
    [SerializeField] protected int changeValueOnHitMultiplier;
    protected float changeValueOnHit;
    [SerializeField] protected TextMeshPro changeValueTMP;
    [SerializeField] protected int currentValueMin;
    [SerializeField] protected int currentValueMax;
    [SerializeField] protected int currentValueMultiplier;
    protected float currentValue;
    [SerializeField] protected TextMeshPro currentValueTMP;
    [SerializeField] protected Material wallMaterial;
    [SerializeField] protected Float variableToChange;

    private void Start()
    {
        changeValueOnHit = Random.Range(changeValueOnHitMin, changeValueOnHitMax) * changeValueOnHitMultiplier;
        currentValue = Random.Range(currentValueMin, currentValueMax) * currentValueMultiplier;

        changeValueTMP.SetText(changeValueOnHit.ToString("0.0"));
        
        UpdateCurrentTMP();
    }

    protected void UpdateCurrentTMP()
    {
        currentValueTMP.text = currentValue.ToString("0");
    }

    public void ApplyDamage(float damage)
    {
        currentValue += changeValueOnHit;
        UpdateCurrentTMP();
    }

    protected override void OnPlayerEnter()
    {
        variableToChange.Value += (currentValue / 100);
    }

}