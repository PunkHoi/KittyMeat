using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private Camera _camera;
    private Vector3 offset;
    private Vector3 startDrag;
    private Quaternion startRotation;
    void Start()
    {
        _camera = GetComponent<Camera>();
        startRotation = transform.rotation;
        if (target != null)
            offset = transform.position - target.position;
    }
    void Update()
    {
        transform.position = target.position + offset;

        if (Input.GetMouseButtonDown(0))
            startDrag = _camera.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            var curMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var deltaMousePosition = curMousePosition - startDrag;
            var angle = Mathf.Atan2(deltaMousePosition.z, deltaMousePosition.x) * Mathf.Rad2Deg;

            Quaternion xQuaternion = Quaternion.AngleAxis(deltaMousePosition.x, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(deltaMousePosition.y, Vector3.left);

            transform.RotateAround(target.position, Vector3.up, angle);
            transform.rotation = startRotation * xQuaternion * yQuaternion;
            startDrag = curMousePosition;
        }
    }
}
