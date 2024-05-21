using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] 
    private float Speed, TimeToRevert;
    [SerializeField] private GameController _gameController;
   
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState;
    private float currentTimeToRevert;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        currentTimeToRevert = 0f;
        currentState = WALK_STATE;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0f;
            currentState = REVERT_STATE;
        }
        
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case REVERT_STATE:
                transform.Rotate(new Vector2(0, -180));
                currentState = WALK_STATE;
                Speed *= -1;
                break;
            case WALK_STATE:
                _rigidbody.velocity = Vector2.right * Speed; 
                break;
        }
        
        _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            currentState = IDLE_STATE;
        }
    }

    private void OnDestroy()
    {
        _gameController.AddPoint(100);
    }
}
