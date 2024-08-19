using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int isLeftOrRight;
    [SerializeField] private bool alreadyGrabbing;

    private GameObject grabbedObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(isLeftOrRight))
        {
            if (isLeftOrRight == 0)
            {
                animator.SetBool("isLeftHandUp", true);
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetBool("isRightHandUp", true);
            }
        }

        if (grabbedObject != null && !grabbedObject.GetComponent<FixedJoint>())
        {
            FixedJoint joint = grabbedObject.AddComponent<FixedJoint>();
            joint.connectedBody = rb;
            joint.breakForce = 9001;
        }
        else if(Input.GetMouseButtonUp(isLeftOrRight))
        {
            if (isLeftOrRight == 0)
            {
                animator.SetBool("isLeftHandUp", false);
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetBool("isRightHandUp", false);
            }

            if (grabbedObject != null)
            {
                Destroy(grabbedObject.GetComponent<FixedJoint>());
            }

            grabbedObject = null;
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            Debug.Log(collider.gameObject);
            grabbedObject = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        grabbedObject = null;
    }
}
