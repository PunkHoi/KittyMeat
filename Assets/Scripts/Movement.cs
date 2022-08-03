using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public FloatingJoystick Joystick;
    public Transform MainCamTransform;
    public Transform FirstViewCamTransform;
    [HideInInspector]
    public bool IsRun;
    [HideInInspector]
    public bool CanMove;

    private float maxSpeed = 1f;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 startOffset;
    private Vector3 direction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        maxSpeed = Speed;
        CanMove = true;
        IsRun = false;
        startOffset = MainCamTransform.position - transform.position;
    }
    void Update()
    {
        if (CanMove && (Joystick.Direction.magnitude > 0) != IsRun)
            _animator.SetBool("IsRun", IsRun = !IsRun);
        if (CanMove && Joystick.Direction.magnitude > 0.1)
            RotateByJoystick();
    }
    void FixedUpdate()
    {
        if (CanMove)
        {
            float _maxSpeed = maxSpeed;
            if (Joystick.Direction.magnitude == 0)
                _maxSpeed = 0;
            _rigidbody.velocity = new Vector3(
                Mathf.Clamp(_rigidbody.velocity.x + direction.x * Speed, -_maxSpeed, _maxSpeed),
                _rigidbody.velocity.y,
                Mathf.Clamp(_rigidbody.velocity.z + direction.y * Speed, -_maxSpeed, _maxSpeed));
        }
    }
    public void ChangeToFirstView()
    {
        MainCamTransform.gameObject.SetActive(false);
        FirstViewCamTransform.gameObject.SetActive(true);
    }
    void RotateByJoystick()
    {
        var offset = MainCamTransform.position - transform.position;
        var angle = AngleBetweenVectors(
            new Vector2(offset.x, offset.z),
            new Vector2(startOffset.x, startOffset.z));
        direction = RotatedVector(Joystick.Direction, -angle);
        transform.rotation = Quaternion.LookRotation(new Vector3(
            direction.x,
            0,
            direction.y
            ));
    }

    float AngleBetweenVectors(Vector2 a, Vector2 b)
    {
        int sign = 1;
        if (a.x * b.y - a.y * b.x > 0)
            sign = -1;
        return sign * Mathf.Acos(Mathf.Clamp((a.x * b.x + a.y * b.y) / (a.magnitude * b.magnitude), -1, 1));
    }
    Vector2 RotatedVector(Vector2 vec, float angle)
    {
        float sin = Mathf.Sin(angle), cos = Mathf.Cos(angle);
        return new Vector2(
            vec.x * cos + vec.y * sin,
            vec.y * cos - vec.x * sin
            );
    }
}
