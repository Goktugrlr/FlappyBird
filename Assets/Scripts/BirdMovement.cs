using UnityEngine;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{

    public float jumpLength;
    Rigidbody2D rb;
    public Text finalScore;
    public float scoreCounter;
    public GameManager manager;
    bool isDead;
    public AudioSource point;
    public AudioSource wing;
    

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        scoreCounter = 0;
        rb.gravityScale = 0;
        manager.StartGame();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * jumpLength;
                rb.gravityScale = 1.7f;
                manager.GameStarted();
                wing.Play();
            }
        }
        manager.updateScore();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Detactor")
        {
            scoreCounter++;
            point.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            isDead = true;
            manager.Death();
        }
    }

}
