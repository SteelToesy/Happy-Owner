using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private Vector2 _moveDirection;
    private bool _grounded;
    private float _jumpForce;

    private Rigidbody2D _rb;
    public BoxCollider2D groundTrigger;

    public InputAction leftRight;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    private void Awake()
    {
        _jumpForce = 400;
        _speed = 10;
        
        _rb = GetComponent<Rigidbody2D>();
        groundTrigger = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _moveDirection = leftRight.ReadValue<Vector2>();
        if (Input.GetKeyDown(KeyCode.Space)) 
            Jump();
    }

    private void FixedUpdate() => Movement();

    private void Movement() => _rb.velocity = new Vector2(_moveDirection.x * _speed, _rb.velocity.y);

    private void Jump()
    {
        if (_grounded) 
            _rb.AddForce(new Vector2(0, _jumpForce));
        _grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision) => _grounded = true;

    private void OnEnable() => leftRight.Enable();

    private void OnDisable() => leftRight.Disable();
}
