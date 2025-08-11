using UnityEngine;

public class Redbrk : BricksScript
{
    void Start()
    {
        BRKHP = 2;
    }

    public override void Break()
    {
        BRKHP--;
        SoundManagerScript.PlaySound(m_Hitsound, transform.position);
        if (BRKHP <= 0)
        {
            FindAnyObjectByType<GameManagerScript>().WINBRKCOUNT -= 1;
            Destroy(gameObject);
        }
        else
        {
            playHitEffect(transform.position);
        }
    }

    public override void playHitEffect(Vector3 p_Position)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Break();
        }
    }
}
