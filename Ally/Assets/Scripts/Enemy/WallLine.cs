using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLine : MonoBehaviour
{
    private ObstacleWall[] _walls;

    private void Awake()
    {
        _walls = GetComponentsInChildren<ObstacleWall>();
    }

    public void SetLineHealth(float health)
    {
        foreach (var wall in _walls)
        {
            wall.SetMaxHealth(health);
        }
    }
}
