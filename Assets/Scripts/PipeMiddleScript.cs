using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicSCript logic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicSCript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.AddScore(1);
            AudioManager.instance.PlaySFX("Score");
        }
    }
}
