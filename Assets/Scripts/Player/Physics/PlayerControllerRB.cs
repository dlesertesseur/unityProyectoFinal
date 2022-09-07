using UnityEngine;

public class PlayerControllerRB : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float jumpForce;
    private float fallMultiplier;

    private float distanceToFloor;

    [SerializeField]
    private bool onGround;

    private Rigidbody playerRb;
    private Vector3 inputVector;

    private float deltaH;

    [SerializeField]
    private string aboveObject;

    public AudioSource jumpSound;

    void Start()
    {
        this.speed = 5.0f;
        this.jumpForce = 8.0f;
        this.fallMultiplier = 2.0f;
        this.deltaH = 0.75f;
        this.playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        JumpControl();
        DistanceToFloor();
    }

    private void JumpControl()
    {
        if (!MenuManager.IsPause())
        { 
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                onGround = false;
                this.playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                this.jumpSound.Play();
            }
        }
    }

    private void MovePlayer()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        inputVector = new Vector3(
            hor * speed, 
            this.playerRb.velocity.y, 
            ver * speed);

        this.transform.LookAt(this.transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    }

    private void FixedUpdate()
    {
        this.playerRb.velocity = inputVector;

        if(this.playerRb.velocity.y < 0)
        {
            this.playerRb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime ; 
        }
    }

    private void DistanceToFloor()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit))
        {
            distanceToFloor = (hit.distance - deltaH);
            onGround = distanceToFloor < 0.05f;
            if (onGround)
            {
                if (hit.collider.gameObject.CompareTag("Platform"))
                {
                    GameObject platform = hit.collider.gameObject;
                    aboveObject = platform.name;
                    this.transform.SetParent(platform.transform);
                }
                else
                {
                    this.transform.SetParent(null);
                    aboveObject = "";
                }
            }
            else
            {
                this.transform.SetParent(null);
                aboveObject = "";
            }
        }
        else
        {
            this.transform.SetParent(null);
            onGround = false;
            aboveObject = "";
        }
    }

    public Rigidbody GetPlayerRB()
    {
        return (this.playerRb);
    }
}