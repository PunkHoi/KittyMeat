using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mouseSensitivity = 3f;
    public Rigidbody rb;
    public Camera cam;
    public float speed = 5f;
    public Vector3 prev_pos;
    private Vector3 transfer;
    public float minimumX = -60f;
    public float maximumX = 600f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationX = 0f;
    float rotationY = 0f;
    Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
            
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
            cam.transform.Rotate(-rotationY, rotationX, 0, Space.World);
            cam.transform.rotation = originalRotation * xQuaternion * yQuaternion;
            rb.AddForce(new Vector3(0, 0, 1 * Input.GetAxis("Vertical"))) ;
            rb.AddForce(new Vector3(1 * Input.GetAxis("Horizontal"),0, 0));
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}
