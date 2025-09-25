using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float deSpawnZone = -40f;
    public BellaScript bellaScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bellaScript = GameObject.FindGameObjectWithTag("Pet").GetComponent<BellaScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bellaScript.birdIsAlive)
        {
            transform.position = transform.position + (moveSpeed * Time.deltaTime * Vector3.left);
        }

        if (transform.position.x < deSpawnZone)
        {
            DespawnPipe();
        }
    }

    void DespawnPipe()
    {
        Destroy(gameObject);
    }

}
