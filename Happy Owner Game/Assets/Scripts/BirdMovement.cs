using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _transform;

    public float _speed;
    private float _startPosition;
    private float tempstartpos;
    public float _magnitude;
    private float _timer;
    private float _multiplier;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = _rb.transform;
        _startPosition = _transform.position.y;
        tempstartpos = _startPosition;

        _multiplier = 1;
        _magnitude = 0.5f;
        _speed = 6.5f;
        _timer = Time.time + 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float time = Time.time;
        if (time > _timer)
            VulnerabilityStage();
        else
            Movement();
    }

    private void Movement()
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        _transform.position = new(_transform.position.x, MathF.Sin(Time.time * _speed) * _magnitude + _startPosition);
    }

    private void VulnerabilityStage()
    {
        _multiplier += 0.5f;
        _timer += 3 * _multiplier;
        if (tempstartpos > _startPosition)
            _startPosition = tempstartpos;
        else
            _startPosition -= 2;
    }
}
