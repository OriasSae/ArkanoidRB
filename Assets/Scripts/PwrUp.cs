using UnityEngine;
using DG.Tweening;

public abstract class PwrUp : MonoBehaviour
{
    [SerializeField] protected float m_Speed = 1f;
    protected Rigidbody2D m_Rigidbody;
    protected SpriteRenderer m_SpriteRenderer;
    AudioClip m_PickUpSound;
    GameObject m_VFX;
    protected bool m_HasCollided;

    protected void start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Rigidbody.linearVelocity = new Vector2(0, -m_Speed);
        m_HasCollided = false;
    }
    protected abstract void Effect();

    public void Collide()
    {
        if (m_HasCollided) 
        SoundManagerScript.PlaySound(m_PickUpSound, transform.position);
        Instantiate(m_VFX, transform.position, Quaternion.identity);
        Effect();
        transform.DOScale(transform.localScale * 2, 0.1f).OnComplete(() => Destroy(gameObject));

    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
