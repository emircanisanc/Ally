using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class PlayerCamera : Singleton<PlayerCamera>
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerStartPosTransform;
    public static CinemachineVirtualCamera VirtualCamera;
    [SerializeField] private Vector3 _cameraStartOffset;
    [SerializeField] private Vector3 _cameraEndOffset;

    private Vector3 _followOffset;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += MovePlayerToStartPos;

        /* VirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        VirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _cameraStartOffset; */
    }

    private void OnDisable() {
        if (GameManager.Instance)
            GameManager.Instance.OnGameStarted -= MovePlayerToStartPos;
    }

    private void MovePlayerToStartPos()
    {
        // VirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _cameraEndOffset;
        transform.DOMove(_playerStartPosTransform.position + _cameraEndOffset, 1f);
        transform.DORotate(new Vector3(25f, 0, 0), 1f).OnComplete(() => canFollowTarget = true);
        _playerTransform.DOMove(_playerStartPosTransform.position, 1f).OnComplete(() => _playerTransform.GetComponent<PlayerMovement>().StartMovement());
    }

    bool canFollowTarget;

    private void Update()
    {
        if (canFollowTarget)
            transform.position = _playerTransform.position + _cameraEndOffset;
    }
}
