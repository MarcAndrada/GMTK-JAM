using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    private void Start()
    {
        controller = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        controller.SetIsGrounded(true);
    }
}
