using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemDropper))]
public class Enemy : EnemyBase
{
    [SerializeField] private Image _healthBarImage;
    private ItemDropper _itemDropper;

    private void Awake()
    {
        _itemDropper = GetComponent<ItemDropper>();    
    }

    protected override void Die()
    {
        base.Die();
        _healthBarImage.fillAmount = _currentHealth / _maxHealth;
        // PLAY PARTICLE
        _itemDropper.DropItems();
    }

    public override void ApplyDamage(float damage)
    {
        base.ApplyDamage(damage);
        // PLAY ANIM
    }
}
