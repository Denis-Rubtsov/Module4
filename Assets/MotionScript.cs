using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    private Camera _camera;

    private Vector3 _input;

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _input = new Vector3(horizontal, 0, vertical);
        Vector3 moveDirection = _camera.transform.TransformDirection(_input);
        moveDirection.y = 0;
        //moveDirection.Normalize();
        transform.forward = moveDirection;
        _controller.Move(_input * _speed * Time.deltaTime);
        _animator.SetFloat("Speed", _controller.velocity.magnitude);
    }
}
