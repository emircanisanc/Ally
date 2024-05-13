using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWallController : MonoBehaviour
{
    private List<BaseBonusWall> _bonusWalls;

    private void Start() 
    {
        _bonusWalls = new List<BaseBonusWall>(GetComponentsInChildren<BaseBonusWall>());
    }

    public bool CanPlayerEnter(BaseBonusWall wall)
    {
        var otherWall = _bonusWalls.Find(x => x != wall);
        if (otherWall.IsInteractable)
        {
            otherWall.IsInteractable = false;
            return true;
        }
        return false;
    }
}
