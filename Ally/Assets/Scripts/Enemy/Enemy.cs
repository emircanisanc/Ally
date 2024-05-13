using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemDropper))]
public class Enemy : EnemyBase
{
    [SerializeField] private Image _healthBarImage;
    private ItemDropper _itemDropper;

    protected override void Awake()
    {
        base.Awake();
        _itemDropper = GetComponent<ItemDropper>();
        _healthBarImage.fillAmount = 1;
    }

    protected override void Die()
    {
        base.Die();
        _healthBarImage.fillAmount = 0f;
        // PLAY PARTICLE
        _itemDropper.DropItems();
    }

    public override void ApplyDamage(float damage)
    {
        base.ApplyDamage(damage);
        _healthBarImage.fillAmount = _currentHealth / _maxHealth;
        // PLAY ANIM
    }

}
