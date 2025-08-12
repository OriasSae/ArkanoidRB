using UnityEngine;

public class Redbrk : BricksScript
{
    void Start()
    {
        BRKHP = 2;
    }

    protected override void InternalBreak()
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
            InternalBreak();
        }
    }

    protected override void InternalSpawnPowerUp()
    {
        if (Random.value < 0.5 && m_PowerUpPrefab != null)
        {
            Instantiate(m_PowerUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
