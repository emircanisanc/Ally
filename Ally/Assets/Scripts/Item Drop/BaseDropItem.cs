using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropItem : MonoBehaviour
{
    protected bool isActive = false;

    public void ActiveItem()
    {
        isActive = true;
    }

    public void DeactiveItem()
    {
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isActive) return;

            OnInteract(other.transform);
        }    
    }

    protected abstract void OnInteract(Transform player);
}
