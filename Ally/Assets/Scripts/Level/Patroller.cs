using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    
    [SerializeField] [Min(1)] private float _patrolMaxX = 1;
    [SerializeField] private float _patrolSpeed = 2f;

    float _patrolLimitX;
    float _patrolSecondLimitX;
    bool isMovingRight;
    
    private void Awake()
    {
        _patrolLimitX = Random.Range(0, _patrolMaxX) + 0.1f;
        _patrolSecondLimitX = Random.Range(-_patrolMaxX, 0) - 0.1f;
        Vector3 startPos = transform.position;
        startPos.x = Random.Range(_patrolSecondLimitX, _patrolLimitX);
        transform.position = startPos;
        isMovingRight = Random.Range(0, 2) == 1;
    }

    void Update()
    {
        if (isMovingRight)
        {
            if (_patrolLimitX - transform.position.x <= 0.1f)
            {
                isMovingRight = false;
            }
            transform.Translate(transform.right * _patrolSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.position.x - _patrolSecondLimitX <= 0.1f)
            {
                isMovingRight = true;
            }
            transform.Translate(-transform.right * _patrolSpeed * Time.deltaTime);
        }
    }
}
