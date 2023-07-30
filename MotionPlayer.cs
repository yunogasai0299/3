using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionPlayer : MonoBehaviour
{
    [SerializeField] private float _motionSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;

    private CharacterController _controller;
    private float _gravity;
    protected Vector3 _motion;
    protected float _rotation;
    protected float _jumpVelocity;
    private readonly float _rotationSpeedFactor = 20;

    protected virtual void Awake()
    {
        _controller = GetComponent<CharacterController>();
        CalculateJump();
    }

    protected virtual void Update()
    {
        Gravitate();
        Move();
        Rotate();

        if (_motion.y < -7.0f)
        {
            Debug.Log("You are Dead");
            transform.position = new Vector3(0, -1.0f, 0);
            Jump();
            
        }
        
        
    }
    
    private void CalculateJump()
    {
        float timeToApex = _jumpTime / 2;
        _gravity = -_jumpHeight * 2 / Mathf.Pow(timeToApex, 2);
        _jumpVelocity = 2 * _jumpHeight / timeToApex;
    }

    protected void Motion(float horizontal, float vertical)
    {
        _motion.x = horizontal * _motionSpeed;
        _motion.z = vertical * _motionSpeed;
    }

    protected void Rotation(float rotation) => _rotation = rotation;

    private void Gravitate()
    {
        if (_controller.isGrounded == false)
            _motion.y += _gravity * Time.deltaTime;
    }

    protected void Jump()
    {
        if (_controller.isGrounded)
            _motion.y = _jumpVelocity;
    }

    public void Dead()
    {
        
    }

    private void Rotate() => transform.Rotate(Vector3.up, _rotation * _rotationSpeed * _rotationSpeedFactor * Time.deltaTime);

    private void Move() => _controller.Move(transform.TransformDirection(_motion * Time.deltaTime));

    protected void SendMessage() => Debug.Log("The key is pressed");
}




