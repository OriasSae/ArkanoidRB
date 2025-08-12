using UnityEditor.VersionControl;
using UnityEngine;
using DG.Tweening;

public abstract class BricksScript : MonoBehaviour
{
    public int BRKHP;
    [SerializeField] protected GameObject m_BreakEffect;
    [SerializeField] protected AudioClip m_Hitsound;
    [SerializeField] protected GameObject m_PowerUpPrefab;

    protected SpriteRenderer m_SpriteRenderer;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected abstract void InternalBreak();

    protected abstract void InternalSpawnPowerUp();

    public void Hit()
    {
        if (m_Hitsound != null)
        {
            Instantiate(m_BreakEffect, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No hit sound assigned for " + name);
        }
        if (m_Hitsound != null)
        {
            SoundManagerScript.PlaySound(m_Hitsound, transform.position);
        } else
        {
            Debug.LogWarning("No hit sound assigned for " + name);
        }
        GameManagerScript.ShakeCamera(0.2f, 0.2f);

        transform.DOScale(transform.localScale * 1.15f, 0.1f).OnComplete(
            () => transform.DOScale(transform.localScale / 1.15f, 0.05f).OnComplete(
                () => InternalBreak())
        );

        Color t_Color = m_SpriteRenderer.color;
        m_SpriteRenderer.DOColor(Color.white, 0.5f).OnComplete(
            () => m_SpriteRenderer.DOColor(t_Color, 0.05f)
        );
        InternalSpawnPowerUp();
        
    }

    public abstract void playHitEffect(Vector3 p_Position);
}

