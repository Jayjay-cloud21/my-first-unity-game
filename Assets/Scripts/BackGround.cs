using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackGround : MonoBehaviour
{
    public BellaScript bellaScript;
    public LogicSCript logicScript;
    public float moveSpeed;
    private float width;

    private Color prevColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        bellaScript = GameObject.FindGameObjectWithTag("Pet").GetComponent<BellaScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicSCript>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        prevColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (logicScript.GetIsGameOver() || logicScript.getIsPaused())
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = prevColor;
        }

        if (!bellaScript.birdIsAlive) return;

        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x <= -width)
        {
            transform.position += 2 * width* Vector3.right;
        }

    }


}
