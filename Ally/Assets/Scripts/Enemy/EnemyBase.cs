using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] [Min(1)] protected float _maxHealth = 1;
    [SerializeField] private float _randomnessOnHealth = 0;
    protected float _currentHealth;

    private void Awake()
    {
        _maxHealth += Random.Range(-_randomnessOnHealth, _randomnessOnHealth);
        _currentHealth = _maxHealth;    
    }

    public virtual void ApplyDamage(float damage)
    {
        if (_currentHealth <= 0) return;
        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        if (_currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {

    }
}