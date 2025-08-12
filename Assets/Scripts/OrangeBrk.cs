using UnityEngine;
using DG.Tweening;

public class OrangeBrk : BricksScript
{
    SpriteRenderer m_SpriteRenderer;
    Color m_OriginalColor;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_OriginalColor = m_SpriteRenderer.color;
    }
    void Start()
    {
        BRKHP = 1;
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
