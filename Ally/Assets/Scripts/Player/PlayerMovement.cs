using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _limitX = 5;
    private Joystick _joystick;
    [SerializeField] private float _moveSpeed = 5f;
    public bool CanMove { get; set; } = false;

    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    public void StartMovement()
    {
        CanMove = true;
        /* PlayerCamera.VirtualCamera.Follow = transform;
        PlayerCamera.VirtualCamera.LookAt = transform; */
    }

    void Update()
    {
        if (!CanMove) return;
            
        Vector3 moveDir = transform.forward;
        moveDir += GetInputDir();

        if (moveDir.x > 0 && transform.position.x >= _limitX) moveDir.x = 0;
        if (moveDir.x < 0 && transform.position.x <= -_limitX) moveDir.x = 0;

        transform.Translate(moveDir * _moveSpeed * Time.deltaTime);
    }

    public void Hit()
    {
        Vector3 target = transform.position;
        target.z -= 5f;

        CanMove = false;
        transform.DOJump(target, 1.2f, 1, 0.35f).OnComplete(() => CanMove = true);
    }

    private Vector3 GetInputDir()
    {
        return _joystick.Horizontal != 0 ? new Vector3(_joystick.Horizontal, 0, 0) : new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
}
