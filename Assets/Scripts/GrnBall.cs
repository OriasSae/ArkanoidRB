using UnityEngine;

public class GrnBall : Ball
{
    protected override void OnBrickCollision(BricksScript p_Brick)
    {
        p_Brick.Break();
    }
    protected override void OnDeathZoneCollision()
{
    base.OnDeathZoneCollision();
}


    protected override void OnPlayerBoardCollision(PlayerBoardScript p_PlayerBoard)
    {
        Vector2 Dir = this.transform.position - p_PlayerBoard.transform.position;
        m_Rigidbody2D.linearVelocity = Dir.normalized * m_Speed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
