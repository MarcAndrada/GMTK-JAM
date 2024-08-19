using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private float stomachOffset;

    [SerializeField] private ConfigurableJoint hipJoint;
    [SerializeField] private ConfigurableJoint stomachJoint;

    private float mouseX;
    private float mouseY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        CameraController();
    }

    private void CameraController()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -25, 40);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.LookAt(target.position);

        hipJoint.targetRotation = Quaternion.Euler(mouseX, 0, 0);
        stomachJoint.targetRotation = Quaternion.Euler(0, 0, -mouseY + stomachOffset);
    }
}
