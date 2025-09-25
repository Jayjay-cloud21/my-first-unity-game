using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0f;
    public float heightOffSet;

    private BellaScript bellaScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bellaScript = GameObject.FindGameObjectWithTag("Pet").GetComponent<BellaScript>();
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bellaScript.birdIsAlive) return;
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    // function that spawns the pipes
    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;
        Vector3 pipeHeightRange = new(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);
        Instantiate(pipe, pipeHeightRange, transform.rotation);
    }
    
}
