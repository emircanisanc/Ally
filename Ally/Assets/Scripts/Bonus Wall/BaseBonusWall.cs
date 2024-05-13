using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class BaseBonusWall : MonoBehaviour
{
    [SerializeField] protected Transform _gfx;
    [SerializeField] protected bool IsActive = true;
    public bool IsInteractable { get; set; } = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsInteractable) return;
            if (!IsActive) return;
            if (transform.parent.GetComponent<BonusWallController>().CanPlayerEnter(this))
            {
                IsInteractable = false;
                GetComponent<Collider>().enabled = false;
                OnPlayerEnter();
                _gfx.DOMoveY(_gfx.position.y - 5f, 1f);
            }
        }
    }

    protected abstract void OnPlayerEnter();
}
