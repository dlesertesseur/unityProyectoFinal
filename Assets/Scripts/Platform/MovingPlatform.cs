using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //public Rigidbody rb;
    public List<Transform> points = new List<Transform>();
    public float speed;

    private int index = 0;

    void Start()
    {
        this.speed = 5.0f;
        this.index = 0;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (this.points.Count > 1)
        { 
            if (Vector3.Distance(this.transform.position, this.points[index].position) <= 0f)
            {
                if (index < this.points.Count - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }

            this.transform.position = Vector3.MoveTowards(
                this.transform.position,
                points[index].position,
                this.speed * Time.deltaTime);

            //rb.MovePosition(Vector3.MoveTowards(
            //    rb.position,
            //    points[index].position,
            //    this.speed * Time.deltaTime));
        }
    }
}
