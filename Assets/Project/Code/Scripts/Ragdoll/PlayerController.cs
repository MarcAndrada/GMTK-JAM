using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float speed;
    [SerializeField] private float strafeSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Rigidbody root;
    private bool isGrounded;

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        ResetMovementAnimations();

        // Handle walking forward and backward
        HandleMovement(KeyCode.W, "isWalking", -transform.up, speed);
        HandleMovement(KeyCode.S, "isWalking", transform.up, speed);

        // Handle strafing left and right
        HandleMovement(KeyCode.A, "isLeftWalking", -transform.forward, strafeSpeed);
        HandleMovement(KeyCode.D, "isRightWalking", transform.forward, strafeSpeed);
    }
    private void HandleMovement(KeyCode key, string animationBool, Vector3 direction, float normalSpeed)
    {
        if (Input.GetKey(key))
        {
            animator.SetBool(animationBool, true);
            root.AddForce(direction * normalSpeed);
        }
    }
    void ResetMovementAnimations()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isLeftWalking", false);
        animator.SetBool("isRightWalking", false);
    }
    public void SetIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 1);
    }

}
