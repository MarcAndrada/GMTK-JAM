using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CopyMotions : MonoBehaviour
{
    [SerializeField] private bool mirror;

    [SerializeField] private Transform targetLimb;

    ConfigurableJoint joint;
    Quaternion startRotation;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startRotation = transform.localRotation;
    }

    private void Update()
    {
        if (!mirror)
        {
            joint.targetRotation = targetLimb.localRotation * startRotation;
        }
        else
        {
            joint.targetRotation = Quaternion.Inverse(targetLimb.localRotation) * startRotation;
        }

    }
}
