using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPhase : MonoBehaviour
{
    [SerializeField] private WallLine[] _wallLines;

    public void SetObstaclesHealth(int startHealth, int healthIncrease)
    {
        for (int i = 0; i < _wallLines.Length; i++)
        {
            _wallLines[i].SetLineHealth(startHealth + healthIncrease * i);
        }
    }
}
