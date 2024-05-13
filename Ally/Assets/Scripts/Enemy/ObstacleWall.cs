using System.Collections;
using System.Collections.Generic;
using TMPro;
using Emir;
using UnityEngine;

public class ObstacleWall : EnemyBase
{
    [SerializeField] private TextMeshPro _healthTMP;

    protected override void SetHealth(float health)
    {
        base.SetHealth(health);
        _healthTMP.text = _currentHealth.ToString("0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Emir.PlayerManager>().Die();
        }    
    }
}
