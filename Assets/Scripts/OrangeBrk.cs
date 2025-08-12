using UnityEngine;
using DG.Tweening;

public class OrangeBrk : BricksScript
{
    public override void playHitEffect(Vector3 p_Position)
    {
        throw new System.NotImplementedException();
    }

    protected override void InternalBreak()
    {
        Destroy(gameObject);
    }

    protected override void InternalSpawnPowerUp()
    {
        if (m_PowerUpPrefab != null)
        {
            Instantiate(m_PowerUpPrefab, transform.position, Quaternion.identity);
        } else {
            Debug.LogWarning("No power-up prefab assigned for " + name);
        }
    }
}
