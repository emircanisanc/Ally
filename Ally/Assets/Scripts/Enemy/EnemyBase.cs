using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject _gfx;
    [SerializeField] [Min(1)] protected float _maxHealth = 1;
    [SerializeField] private float _randomnessOnHealth = 0;
    protected float _currentHealth;

    protected virtual void Awake()
    {
        SetMaxHealth(_maxHealth + Random.Range(-_randomnessOnHealth, _randomnessOnHealth));
    }

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        SetHealth(_maxHealth);
    }

    protected virtual void SetHealth(float health)
    {
        _currentHealth = health;
    }

    public virtual void ApplyDamage(float damage)
    {
        if (_currentHealth <= 0) return;
        SetHealth(Mathf.Max(0, _currentHealth - damage));
        if (_currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        _gfx.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.collider.GetComponent<PlayerMovement>().Hit();
            other.collider.SendMessage("Hit");
            GetComponent<Collider>().isTrigger = true;
        }    
    }
}
