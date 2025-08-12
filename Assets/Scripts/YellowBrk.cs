using UnityEngine;

public class YellowBrk : BricksScript
{
    [SerializeField] private GameObject yellowBallPrefab; // Assign in inspector

    void Start()
    {
        BRKHP = 3;
    }

    protected override void InternalBreak()
    {
        BRKHP--;
        SoundManagerScript.PlaySound(m_Hitsound, transform.position);
        if (BRKHP <= 0)
        {
            var gm = FindAnyObjectByType<GameManagerScript>();
            gm.WINBRKCOUNT -= 1;
            var spawner = FindAnyObjectByType<BallSpwn>();
            if (spawner != null && yellowBallPrefab != null)
            {
                spawner.SpawnSpecificBall(yellowBallPrefab);
            }
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
        throw new System.NotImplementedException();
    }
}
