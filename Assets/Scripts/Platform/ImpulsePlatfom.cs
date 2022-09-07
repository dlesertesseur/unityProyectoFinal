using UnityEngine;

public class ImpulsePlatfom : MonoBehaviour
{
    private float timeLeft;
    private bool activeTimer;
    private float impulceForce;
    private GameObject go = null;
    private PlayerControllerRB player = null;
    public AudioSource impulseSound;

    private void Start()
    {
        activeTimer = false;
        timeLeft = 0.0f;
        impulceForce = 20.0f;
        this.go = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        timeLeft = 1.0f;

        go = other.gameObject;
        if (go.CompareTag("Player"))
        {
            player = go.GetComponent(typeof(PlayerControllerRB)) as PlayerControllerRB;
            this.activeTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.activeTimer = false;
        this.go = null;
        Debug.Log("ImpulsePlayer() -> CANCEL");
    }

    void Update()
    {
        if (this.activeTimer)
        { 
            if (this.timeLeft > 0)
            {
                this.timeLeft -= Time.deltaTime;
            }
            else
            {
                this.timeLeft = 0;
                this.ImpulsePlayer();
                this.activeTimer = false;
            }
        }
    }

    private void ImpulsePlayer()
    {
        Rigidbody rb;
        if (player != null)
        {
            rb = player.GetPlayerRB();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * impulceForce, ForceMode.VelocityChange);
                Debug.Log("ImpulsePlayer() -> AddForce");

                if (impulseSound != null)
                {
                    impulseSound.Play();
                }
            }
        }
    }
}
