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

    private int _gameCounter;

    private void Awake()
    {
        Instance = this;

        _gameCounter = PlayerPrefs.GetInt("gameCount", 0);

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

        GameManager.Instance.OnGameStarted += UpdateGameCount;
    }

    private void Start()
    {
        var finalPlane = Instantiate(_finalPhasePf);
        finalPlane.transform.position = new Vector3(0, 0, _roadCount * _distanceBetweenObstacles);
        if (WeaponInventoryManager.Instance.TryGetWeaponAt(GameManager.Instance.PlayerLevel, out var weaponData))
        {
            Vector3 pos = finalPlane.GetComponentInChildren<LevelEnding>().transform.position;
            Instantiate(weaponData.WeaponVisualPF, pos + new Vector3(0, 4, 0), Quaternion.identity);
        }
    }

    private void OnDestroy() {
        if (GameManager.Instance) GameManager.Instance.OnGameStarted -= UpdateGameCount;
    }

    private void UpdateGameCount()
    {
        _gameCounter++;
        PlayerPrefs.SetInt("gameCount", _gameCounter);
    }


    [System.Serializable]
    public class LevelDesignObjects
    {
        public GameObject[] _pfs;
    }

}
