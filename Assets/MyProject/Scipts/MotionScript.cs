using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    private float _speed;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    private Camera _camera;

    public void Construct(Camera camera, float speed)
    {
        _camera = camera;
        SetSpeed(speed);
    }

    internal void Move(Vector3 motion)
    {
        if (motion.sqrMagnitude > 0.05f)
        {
            Vector3 moveDirection = _camera.transform.TransformDirection(motion);
            moveDirection.y = 0;
            moveDirection.Normalize();
            transform.forward = moveDirection;
            moveDirection += Physics.gravity;
            _controller.Move(motion * _speed * Time.deltaTime);
            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }
        else _animator.SetFloat("Speed", 0);
    }

    public void SetSpeed(float speed) => _speed = speed;

    // Update is called once per frame
    void Update()
    {
    }
}
