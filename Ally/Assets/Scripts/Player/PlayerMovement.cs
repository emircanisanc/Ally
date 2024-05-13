using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _limitX = 5;
    private Joystick _joystick;
    [SerializeField] private float _moveSpeed = 5f;
    public bool CanMove { get; set; } = true;

    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();

        var vCam = FindObjectOfType<CinemachineVirtualCamera>();
        vCam.Follow = transform;
        vCam.LookAt = transform;
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

    private Vector3 GetInputDir()
    {
        return _joystick.Horizontal != 0 ? new Vector3(_joystick.Horizontal, 0, 0) : new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
}