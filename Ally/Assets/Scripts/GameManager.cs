using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action OnGameStarted;
    public Action OnGameEnd;

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }
}
