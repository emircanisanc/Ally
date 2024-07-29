using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private LevelDesignObjects[] _levelDesignObjects;
    [SerializeField] [Min(1)] private int _minRoadCount = 1;
    [SerializeField] [Min(2)] private int _maxRoadCount = 2;
    private int _roadCount;
    public int RoadCount => _roadCount;
    [SerializeField] [Min(1)] private float _distanceBetweenObstacles = 10;
    public float DistanceBetweenObstacles => _distanceBetweenObstacles;

    [System.Serializable]
    public class LevelDesignObjects
    {
        public GameObject[] _pfs;
    }

    public void Create(Transform groundTransform)
    {
        _roadCount = Random.Range(_minRoadCount, _maxRoadCount);

        Vector3 groundScale = groundTransform.localScale;
        groundScale.z *= _roadCount;
        groundTransform.localScale = groundScale;

        for (int i = 1; i < _roadCount + 1; i++)
        {
            Vector3 pos = transform.position;
            pos.z = i * _distanceBetweenObstacles;
            int elementIndex = Random.Range(0, _levelDesignObjects.Length);
            int pfIndex = Random.Range(0, _levelDesignObjects[elementIndex]._pfs.Length);
            var obstacle = Instantiate(_levelDesignObjects[elementIndex]._pfs[pfIndex]);
            obstacle.transform.position = pos;
        }
    }

}
