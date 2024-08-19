using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FollowXZAxis : MonoBehaviour
{
    public Transform parentTransform;
    void Update()
    {
        if (parentTransform != null)
        {
            Vector3 currentPosition = transform.position;

            currentPosition.x = parentTransform.position.x;
            currentPosition.z = parentTransform.position.z;

            transform.position = currentPosition;
        }
    }
}
