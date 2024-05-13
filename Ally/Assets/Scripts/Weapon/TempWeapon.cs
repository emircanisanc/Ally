using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeapon : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private float _range = 5f;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _fireDuration = 1f;
    private float _nextFireTime;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * _range);    
    }

    void Update()
    {
        if (Time.time < _nextFireTime) return;

        _nextFireTime = Time.time + _fireDuration;

        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, _range, _enemyLayers))
        {
            if (hitInfo.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }
}
