using UnityEngine;

public abstract class PickableObject : MonoBehaviour
{
    [SerializeField]
    protected PickableObjectData data;

    private bool isPickable;
    private bool stored;
    private bool activeRespawn;
    private Vector3 respawnPosition;
    private Transform originalParent;

  
    private void Start()
    {
       this.stored = false;
       this.isPickable = true;
       this.activeRespawn = true;
       this.SetRespawnPosition();
    }

    private void Update()
    {
        this.CheckRespawn();
    }

    public PickableObjectData GetData()
    {
        return (this.data);
    }

    public bool IsPickable()
    {
        return (this.isPickable);
    }

    public void SetPicked(bool b)
    {
        this.isPickable = b;
    }

    public void SetActiveRespawn(bool b)
    {
        this.activeRespawn = b;
    }

    public bool IsActiveRespawn()
    {
        return (this.activeRespawn);
    }

    public void SetRespawnPosition()
    {
        this.respawnPosition = this.transform.position + new Vector3(0,1,0);
        this.originalParent = this.transform.parent;
    }

    private void CheckRespawn()
    {
        if (this.transform.position.y < -10)
        {
            this.SetPicked(true);
            this.transform.SetParent(this.originalParent);

            if (this.respawnPosition != null)
            {
                this.transform.position = this.respawnPosition;
            }
            else
            {
                this.transform.position = new Vector3(0, 0.1f, 0);
            }

            this.transform.Rotate(0, 0, 0);
        }
    }

    public virtual Quaternion InitialRotation()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        return (rotation);
    }

    public void Stored()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            this.stored = true;
            rigidbody.isKinematic = true;
        }
    }

    public bool IsStored()
    {
        return (this.stored);
    }
}
