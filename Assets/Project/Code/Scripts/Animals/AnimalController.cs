using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;
    private int currentWayPoint;
    [SerializeField]
    private float minWaypointDistance;
    
    [Space, SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;


    private Rigidbody rb;   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceToWayPoint();
    }

    private void CheckDistanceToWayPoint()
    {
        if (IsNearToWayPoint())
            ChangeWayPoint();
    }

    private bool IsNearToWayPoint()
    {
        return Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) <= minWaypointDistance;
    }

    private void ChangeWayPoint()
    {
        currentWayPoint++;

        if (currentWayPoint < wayPoints.Length)
            return;

        currentWayPoint = 0;
    }


    private void Bounce()
    {
        Vector3 jumpForce = Vector3.up * jumpHeight;
        

        Vector3 wayPointNeutralPosition, currentNeutralPosition;
        wayPointNeutralPosition = new Vector3(wayPoints[currentWayPoint].position.x, 0, wayPoints[currentWayPoint].position.z);
        currentNeutralPosition = new Vector3(transform.position.x, 0, transform.position.z);

        Vector3 waypointDirection = (wayPointNeutralPosition - currentNeutralPosition).normalized;

        Vector3 forwardForce = waypointDirection * speed;

        rb.AddForce(jumpForce + forwardForce, ForceMode.Impulse);

        transform.forward = waypointDirection;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Bounce();
        }
    }
}
