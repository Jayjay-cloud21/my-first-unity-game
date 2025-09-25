using UnityEngine;

public class BellaScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float flapStrength;
    public LogicSCript logic;
    public bool birdIsAlive = true;
    private Vector3 petPos;
    private DeadPets dead;

    public float deadPetSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicSCript>();
        dead = GameObject.FindGameObjectWithTag("Pet").GetComponent<DeadPets>();
        AudioManager.instance.PlayMusic("Bg Music");
        AudioManager.instance.musicSource.loop = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (logic.getIsPaused()) return;

        // this updates the current position of the pet
        petPos = Camera.main.WorldToViewportPoint(transform.position);

        // this will make Bella jump
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
            AudioManager.instance.PlaySFX("Jump");
        }

        
        // games over if Bella is out of the screen
        if (petPos.y > 1.1 || petPos.y < -0.1)
        {
            logic.GameOver();
            birdIsAlive = false;
            dead.OutOfBounds();
            // Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlaySFX("Game Over");
        logic.GameOver();
        birdIsAlive = false;
        dead.HitPole();
        float minX = -5f;
        float maxX = 5f;
        float minY = -5f;
        float maxY = 5f;

        Vector2 randomVector = new(Random.Range(minX, maxX), Random.Range(minY, maxY));
        float randSpeed = Random.Range(1f, 20f);
        rb.linearVelocity = randomVector * randSpeed;
    }
}
