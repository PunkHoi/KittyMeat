using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float MaxSpeed = 1f;
    public bool IsRun;
    public FloatingJoystick Joystick;

    private Rigidbody _rigidbody;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Joystick.Direction.magnitude > 0) != IsRun)
            _animator.SetBool("IsRun", IsRun = !IsRun);
        if (Joystick.Direction.magnitude > 0.1)
            transform.rotation = Quaternion.LookRotation(new Vector3(
                Joystick.Direction.x,
                0,
                Joystick.Direction.y
            ));
    }
    void FixedUpdate()
    {
        float _maxSpeed = MaxSpeed;
        if (Joystick.Direction.magnitude == 0)
            _maxSpeed = 0;
        _rigidbody.velocity = new Vector3(
            Mathf.Clamp(_rigidbody.velocity.x + Joystick.Direction.x * Speed, -_maxSpeed, _maxSpeed),
            _rigidbody.velocity.y,
            Mathf.Clamp(_rigidbody.velocity.z + Joystick.Direction.y * Speed, -_maxSpeed, _maxSpeed));
    }
}
