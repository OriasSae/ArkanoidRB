using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    protected Rigidbody2D m_Rigidbody2D;
    protected float m_Speed;

    [SerializeField] protected AudioClip m_HitSound;
    [SerializeField] protected GameObject m_EffectPrefab;

    protected abstract void OnBrickCollision(BricksScript p_Brick);
    protected abstract void OnPlayerBoardCollision(PlayerBoardScript p_PlayerBoard);

    // Now virtual so we can add the check
    protected virtual void OnDeathZoneCollision()
    {
        Destroy(gameObject);

        // Wait until end of frame to ensure this object is destroyed before counting
        StartCoroutine(CheckBallsLeftAndGameOver());
    }

    private System.Collections.IEnumerator CheckBallsLeftAndGameOver()
    {
        yield return new WaitForEndOfFrame();
        if (FindObjectsByType<Ball>(FindObjectsSortMode.None).Length == 0)
        {
            var gm = FindAnyObjectByType<GameManagerScript>();
            if (gm != null)
                gm.GameOver();
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BricksScript p_Brick))
        {
            OnBrickCollision(p_Brick);
        }
        else if (collision.gameObject.TryGetComponent(out PlayerBoardScript p_PlayerBoard))
        {
            OnPlayerBoardCollision(p_PlayerBoard);
        }
        else if (collision.gameObject.CompareTag("GameOver"))
        {
            OnDeathZoneCollision();
        }
    }

    void Update()
    {
        
    }
}
