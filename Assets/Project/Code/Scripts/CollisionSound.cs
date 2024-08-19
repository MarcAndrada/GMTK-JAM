using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip hitClip;

    private float soundHitMultiplier = 0.1f;
    private float minMagnitude = 0.6f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb && rb.velocity.magnitude >= minMagnitude)
            AudioManager.instance.Play3dOneShotSound(hitClip, "Master", 10, transform.position, Mathf.Clamp(rb.velocity.magnitude * soundHitMultiplier, 0.1f, 1.3f), 0.5f, 1.5f);
    }
}
