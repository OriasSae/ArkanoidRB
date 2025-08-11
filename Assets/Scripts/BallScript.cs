using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Rigidbody2D rb2D;

    public float speed = 1500;

    private Vector2 vlc;

    Vector2 startPosi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosi = transform.position;

        ResBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Object.FindFirstObjectByType<GameManagerScript>().GameOver();
        }
        else if (collision.gameObject.CompareTag("PlayerBoard"))
        {
            float x = HitFactor(
                transform.position,
                collision.transform.position,
                collision.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            rb2D.linearVelocity = dir * rb2D.linearVelocity.magnitude;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 boardPos, float boardWidth)
    {
        return (ballPos.x - boardPos.x) / (boardWidth / 2);
    }

    public void ResBall()
    {
        transform.position = startPosi;

        rb2D.linearVelocity = Vector2.zero;

        vlc.x = Random.Range(-1f, 1f);

        vlc.y = 1;

        rb2D.AddForce(vlc * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
