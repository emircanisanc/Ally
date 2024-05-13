using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMoney : BaseDropItem
{
    protected override void OnInteract(Transform player)
    {
        Destroy(gameObject);
    }
}
