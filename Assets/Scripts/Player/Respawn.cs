using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject toRespawn = null;
    public AudioSource raspawnSound;

    void Update()
    {
        if (toRespawn.transform.position.y < -10 || Input.GetKeyUp(KeyCode.Q))
        {
            toRespawn.transform.position = new Vector3(0, 0.1f, 0);

            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            toRespawn.transform.rotation = rotation;
            raspawnSound.Play();
        }
    }
}
