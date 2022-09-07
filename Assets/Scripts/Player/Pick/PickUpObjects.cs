using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPick = null;
    public GameObject PickedObject = null;
    public Transform PickingPoint = null;

    public void PickUpObject(GameObject gameObject)
    {
        if (this.PickedObject == null)
        { 
            this.ObjectToPick = gameObject;
        }
    }

    private void Update()
    {
        Rigidbody rb; 
        if (this.ObjectToPick != null &&
            this.ObjectToPick.GetComponent<PickableObject>().IsPickable() &&
            this.PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.PickedObject = this.ObjectToPick;
                this.PickedObject.GetComponent<PickableObject>().SetRespawnPosition();
                this.PickedObject.GetComponent<PickableObject>().SetPicked(false);
                this.PickedObject.transform.SetParent(this.PickingPoint);
                this.PickedObject.transform.localPosition = Vector3.zero;
                this.PickedObject.transform.rotation = this.ObjectToPick.GetComponent<PickableObject>().InitialRotation();

                rb = this.PickedObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                this.ObjectToPick = null;
            }
        }
        else
        {
            if (this.PickedObject != null)
            { 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.PickedObject.GetComponent<PickableObject>().SetPicked(true);
                    this.PickedObject.transform.SetParent(null);

                    rb = this.PickedObject.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    this.PickedObject = null;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickableObject"))
        {
           this.PickUpObject(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PickableObject"))
        {
            this.PickUpObject(null);
        }
    }
}
