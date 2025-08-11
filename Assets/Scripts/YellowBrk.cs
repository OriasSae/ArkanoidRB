using UnityEngine;

public class YellowBrk : BricksScript
{
    void Start()
    {
        BRKHP = 3;
    }

    public override void Break()
    {
        BRKHP--;
        SoundManagerScript.PlaySound(m_Hitsound, transform.position);
        if (BRKHP <= 0)
        {
            var gm = FindAnyObjectByType<GameManagerScript>();
            gm.WINBRKCOUNT -= 1;
            gm.HP += 1;
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
