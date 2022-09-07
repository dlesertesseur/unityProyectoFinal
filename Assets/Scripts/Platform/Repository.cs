using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    public GameObject startPositionToStore;
    private List<PickableObject> contents = null;
    private List<Vector3> positions = null;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        this.contents = new List<PickableObject>();

        this.CreateStorePositions();
    }

    private void CreateStorePositions()
    {
        int col;
        int row;
        int cantCol = 6;
        int cantRow = 10;
        float deltaY = 1.3f;
        float deltaZ = 1.3f;
        float x = 0;
        float y;
        float z;
        Vector3 pos;

        positions = new List<Vector3>();
        for (row = 0, y = 0; row < cantRow; row++)
        {
            for (col = 0, z = 0; col < cantCol; col++, z += deltaZ)
            {
                pos = new Vector3(x, -y, z);
                this.positions.Add(pos);
            }
            y += deltaY;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        PickableObject po = go.GetComponent(typeof(PickableObject)) as PickableObject;

        if (po != null && po.GetData() != null && po.IsPickable() && !po.IsStored())
        {
            audioSource.Play();
            PlayerManager.IncreasePoints(po.GetData().poPoints);
            go.transform.position = GetNextPosition();
            go.transform.localRotation = po.InitialRotation();
            go.transform.SetParent(this.startPositionToStore.transform);
            po.Stored();
            this.contents.Add(po);
        }
    }

    private Vector3 GetNextPosition()
    {
        Vector3 pos;
        pos = this.startPositionToStore.transform.position - this.positions[this.contents.Count];
        return (pos);
    }
}
