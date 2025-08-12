using System.Numerics;
using UnityEngine;

public class YlwBall : Ball
{
    [SerializeField] private GameObject m_BallPrefab; 

    protected override void OnBrickCollision(BricksScript p_Brick)
    {
        p_Brick.Hit();

        if (Random.value < 0.25f && m_BallPrefab != null)
        {
            GameObject newBall = Instantiate(m_BallPrefab, transform.position, UnityEngine.Quaternion.identity);
            if (newBall.TryGetComponent<Rigidbody2D>(out var rb))
            {
                UnityEngine.Vector2 randomDir = Random.insideUnitCircle.normalized;
                if (randomDir == UnityEngine.Vector2.zero) randomDir = UnityEngine.Vector2.up;
                rb.linearVelocity = randomDir * (m_Rigidbody2D != null ? m_Rigidbody2D.linearVelocity.magnitude : 5f);
            }
        }
    }

    protected override void OnDeathZoneCollision()
{
    base.OnDeathZoneCollision();
}

    protected override void OnPlayerBoardCollision(PlayerBoardScript p_PlayerBoard)
    {
        UnityEngine.Vector2 Dir = this.transform.position - p_PlayerBoard.transform.position;
        m_Rigidbody2D.linearVelocity = Dir.normalized * m_Speed;
    }

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Speed = 5f;
    }

    void Update()
    {
        
    }
}
