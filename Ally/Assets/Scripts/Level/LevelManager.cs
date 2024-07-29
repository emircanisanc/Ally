using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelManager Instance { get; private set; }
    [SerializeField] private GameObject _finalPhasePf;
    [SerializeField] [Min(0)] private int _level = 0;
    [SerializeField] private Transform _groundTransform;
    

    private int _gameCounter;

    private void Awake()
    {
        Instance = this;

        _gameCounter = PlayerPrefs.GetInt("gameCount", 0);
    }

    private void Start()
    {
        CreateLevel();

        GameManager.Instance.OnGameStarted += UpdateGameCount;
    }

    

    private void OnDestroy() {
        if (GameManager.Instance) GameManager.Instance.OnGameStarted -= UpdateGameCount;
    }

    private void UpdateGameCount()
    {
        _gameCounter++;
        PlayerPrefs.SetInt("gameCount", _gameCounter);
    }

    [SerializeField] private int[] _obstacleHealthStarts;
    [SerializeField] private int[] _obstacleHealthIncreases;

    private void CreateLevel()
    {
        int levelStyleCount = _levelPatterns.Length;
        int levelStyle = _gameCounter % levelStyleCount;
        LevelCreator levelPattern = Instantiate(_levelPatterns[levelStyle]).GetComponent<LevelCreator>();
        levelPattern.Create(_groundTransform);
        var finalPlane = Instantiate(_finalPhasePf);
        finalPlane.transform.position = new Vector3(0, 0, levelPattern.RoadCount * levelPattern.DistanceBetweenObstacles);

        _level = GameManager.Instance.PlayerLevel - 1;

        finalPlane.GetComponent<FinalPhase>().SetObstaclesHealth(_obstacleHealthStarts[Mathf.Min(_level, _obstacleHealthStarts.Length - 1)], _obstacleHealthIncreases[Mathf.Min(_level, _obstacleHealthIncreases.Length - 1)]);

        if (WeaponInventoryManager.Instance.TryGetWeaponAt(GameManager.Instance.PlayerLevel, out var weaponData))
        {
            Vector3 pos = finalPlane.GetComponentInChildren<LevelEnding>().transform.position;
            Instantiate(weaponData.WeaponVisualPF, pos + new Vector3(0, 4, 0), Quaternion.identity);
        }

    }

    [SerializeField] private GameObject[] _levelPatterns;

    

}
