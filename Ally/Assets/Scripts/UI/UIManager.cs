using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _gameEndPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private Button _btnContinueGameOver;
    [SerializeField] private Button _btnContinueGameEnd;

    protected override void Awake()
    {
        base.Awake();

        _startPanel.SetActive(true);
        _inGamePanel.SetActive(false);
        _gameEndPanel.SetActive(false);
        _gameOverPanel.SetActive(false);

        _btnContinueGameEnd.onClick.AddListener(RestartGame);
        _btnContinueGameOver.onClick.AddListener(RestartGame);
    }

    public void ShowInGamePanel()
    {
        _startPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _gameEndPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }

    public void ShowGameOverPanel()
    {
        _startPanel.SetActive(false);
        _inGamePanel.SetActive(false);
        _gameEndPanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    public void ShowEndGamePanel(bool isWeaponUnlocked)
    {
        _startPanel.SetActive(false);
        _inGamePanel.SetActive(false);
        _gameEndPanel.SetActive(true);
        _gameOverPanel.SetActive(false);

        // SHOW WEAPON
    }
}
