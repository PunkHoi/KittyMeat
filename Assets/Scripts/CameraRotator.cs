using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProceduralToolkit.Examples
{
    /// <summary>
    /// Simple camera controller
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class CameraRotator : UIBehaviour, IDragHandler
    {
        public Transform cameraTransform;
        public Transform target;
        [Header("Position")]
        public float distance = 30;
        public float yOffset = 1;
        [Header("Rotation")]
        public float tiltMin = -85;
        public float tiltMax = 85;
        public float rotationSensitivity = 0.5f;
        public float rotationSpeed = 20;


        private GameManager gameManager;
        private float lookAngle;
        private float tiltAngle;
        private Quaternion rotation;

        protected override void Awake()
        {
            base.Awake();
            tiltAngle = (tiltMin + tiltMax) / 2;

            if (cameraTransform == null || target == null) return;

            cameraTransform.rotation = rotation = Quaternion.Euler(tiltAngle, lookAngle, 0);
            cameraTransform.position = CalculateCameraPosition();
        }

        protected override void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        private void LateUpdate()
        {
            if (cameraTransform == null || target == null || !gameManager.IsPlayerCanRotateView)
                return;

            if (cameraTransform.rotation != rotation)
            {
                cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, rotation,
                    Time.deltaTime * rotationSpeed);
            }

            cameraTransform.position = CalculateCameraPosition();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (cameraTransform == null || target == null || !gameManager.IsPlayerCanRotateView)
                return;

            lookAngle += eventData.delta.x * rotationSensitivity;
            tiltAngle -= eventData.delta.y * rotationSensitivity;
            tiltAngle = Mathf.Clamp(tiltAngle, tiltMin, tiltMax);
            rotation = Quaternion.Euler(tiltAngle, lookAngle, 0);
        }

        private Vector3 CalculateCameraPosition()
        {
            return target.position + cameraTransform.rotation * (Vector3.back * distance) + Vector3.up * yOffset;
        }
    }
}