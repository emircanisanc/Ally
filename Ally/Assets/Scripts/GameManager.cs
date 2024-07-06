using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStarted;
    public Action OnGameEnd;

    private int _playerLevelCount;
    public int PlayerLevel => _playerLevelCount;

    protected override void Awake()
    {
        base.Awake();
        _playerLevelCount = PlayerPrefs.GetInt("playerLevel", 1);
    }

    public void StartGame()
    {
        UIManager.Instance.ShowInGamePanel();
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;
        player.CanMove = false;

        UIManager.Instance.ShowGameOverPanel();
    }

    public void FinishGame()
    {
        bool isWeaponUnlocked = WeaponInventoryManager.Instance.TryNewWeaponUnlock(_playerLevelCount);

        if (isWeaponUnlocked)
        {
            PlayerPrefs.SetInt("playerLevel", PlayerLevel + 1);
        }

        UIManager.Instance.ShowEndGamePanel(isWeaponUnlocked);

        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;
        player.CanMove = false;
        OnGameEnd?.Invoke();
    }
}
