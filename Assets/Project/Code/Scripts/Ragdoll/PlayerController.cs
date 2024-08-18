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
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                root.AddForce(-transform.up * speed * 1.5f);
            }
            else
            {
                root.AddForce(-transform.up * speed);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isLeftWalking", true);
            animator.SetBool("isWalking", false);
            root.AddForce(-transform.forward * strafeSpeed);
        }
        else
        {
            animator.SetBool("isLeftWalking", false);

        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            root.AddForce(transform.up * speed);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRightWalking", true);
            animator.SetBool("isWalking", false);
            root.AddForce(transform.forward * strafeSpeed);
        }
        else
        {
            animator.SetBool("isRightWalking", false);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                root.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
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
