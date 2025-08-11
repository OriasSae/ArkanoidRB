using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    protected Rigidbody2D m_Rigidbody2D;
    protected float m_Speed;

    [SerializeField] protected AudioClip m_HitSound;
    [SerializeField] protected GameObject m_EffectPrefab;

    protected abstract void OnBrickCollision(BricksScript p_Brick);
    protected abstract void OnPlayerBoardCollision(PlayerBoardScript p_PlayerBoard);
    protected abstract void OnDeathZoneCollision();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        else if (collision.gameObject.CompareTag("DeathZone"))
        {
            OnDeathZoneCollision();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
