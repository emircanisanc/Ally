using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnInteract(other.transform);
        }    
    }

    protected abstract void OnInteract(Transform player);
}
