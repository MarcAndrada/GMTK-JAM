using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int mouseButtonIndex;
    [SerializeField] private bool alreadyGrabbing;

    public GameObject grabbedObject;
    private FixedJoint grabJoint;
    private bool isHoldingMouse;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(mouseButtonIndex))
        {
            SetHandAnimation(true);
            AttemptGrab();
        }
        if (Input.GetMouseButtonUp(mouseButtonIndex)) 
        { 
            SetHandAnimation(false);
            ReleaseObject();
        }
    }

    private void SetHandAnimation(bool isHandUp)
    {
        if (mouseButtonIndex == 0)
        {
            animator.SetBool("isLeftHandUp", isHandUp);
        }
        else if (mouseButtonIndex == 1)
        {
            animator.SetBool("isRightHandUp", isHandUp);
        }
    }
    private void AttemptGrab()
    {
        if (grabbedObject != null && grabJoint == null)
        {
            grabJoint = grabbedObject.AddComponent<FixedJoint>();
            grabJoint.connectedBody = rb;
            grabJoint.breakForce = 9001;
        }
    }
    public void ReleaseObject()
    {
        if (grabJoint != null)
        {
            Destroy(grabJoint);
            grabJoint = null;
            grabbedObject = null;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            Debug.Log(collider.gameObject);
            grabbedObject = collider.gameObject;

            if (Input.GetMouseButton(mouseButtonIndex))
            {
                AttemptGrab();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        grabbedObject = null;
    }
}
