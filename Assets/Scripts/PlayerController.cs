using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float health = 50f;
    [SerializeField] private float enemyDamage = 10f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private Transform legsColliderTransform;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Text healthText;
    
    private bool isGrounded = false;
    private Rigidbody2D _rigidbody;
    private bool isJumpButtonPressed;
    private SpriteRenderer _renderer;
    private int currentDirection = 1;
    private Animator _animator;
    private Shooter _shooter;
    private GameController _gameController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _shooter = GetComponent<Shooter>();
        _gameController = GetComponent<GameController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        SetHealthText();
        var direction = Input.GetAxis("Horizontal");
        var axisDirection = Input.GetAxisRaw("Horizontal");
        isJumpButtonPressed = Input.GetButtonDown("Jump");
        if (isJumpButtonPressed)
        {
            Jump();
        }
        
        if (axisDirection != 0 && axisDirection*currentDirection < 0)
        {
            transform.Rotate(new Vector2(0, -180));
            currentDirection *= -1;
        }

        if (axisDirection == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }
        
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction, axisDirection);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _shooter.Shoot(currentDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = legsColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(pos, jumpOffset, groundMask);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction, float axisDirection)
    {
        _rigidbody.velocity = new Vector2(curve.Evaluate(direction)*speed, _rigidbody.velocity.y);
    }

    private void SetHealthText()
    {
        healthText.text = "Здоровье: " + health;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= enemyDamage;
            CheckHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _gameController.OnLevelFinished();
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            _gameController.OnGameOver();
        } 
        SetHealthText();
    }
}
