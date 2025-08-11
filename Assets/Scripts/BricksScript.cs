using UnityEditor.VersionControl;
using UnityEngine;

public abstract class BricksScript : MonoBehaviour
{
    public int BRKHP;
    [SerializeField] protected GameObject m_BreakEffect;
    [SerializeField] protected AudioClip m_Hitsound;

    public abstract void Break();

    public abstract void playHitEffect(Vector3 p_Position);
}

