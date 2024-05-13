using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelManager Instance { get; private set; }
    [SerializeField] private GameObject _finalPhasePf;
    [SerializeField] [Min(0)] private int _level = 0;
    [SerializeField] private LevelDesignObjects[] _levelDesignObjects;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] [Min(1)] private int _minRoadCount = 1;
    [SerializeField] [Min(2)] private int _maxRoadCount = 2;
    private int _roadCount;
    [SerializeField] [Min(1)] private float _distanceBetweenObstacles = 10;

    private void Awake()
    {
        Instance = this;

        _roadCount = Random.Range(_minRoadCount, _maxRoadCount);

        Vector3 groundScale = _groundTransform.localScale;
        groundScale.z *= _roadCount;
        _groundTransform.localScale = groundScale;

        for (int i = 1; i < _roadCount + 1; i++)
        {
            Vector3 pos = transform.position;
            pos.z = i * _distanceBetweenObstacles;
            var obstacle = Instantiate(_levelDesignObjects[Random.Range(0, _levelDesignObjects.Length)]._pfs[0]);
            obstacle.transform.position = pos;
        }

        var finalPlane = Instantiate(_finalPhasePf);
        finalPlane.transform.position = new Vector3(0, 0, _roadCount * _distanceBetweenObstacles);
    }


    [System.Serializable]
    public class LevelDesignObjects
    {
        public GameObject[] _pfs;
    }

}
