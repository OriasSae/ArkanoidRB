using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    #region Singleton
    private static SoundManagerScript EnsureInstance()
    {
        SoundManagerScript t_Instance = FindFirstObjectByType<SoundManagerScript>();
        if (t_Instance == null)
        {
            GameObject t_GameObject = new GameObject("SoundManager");
            t_Instance = t_GameObject.AddComponent<SoundManagerScript>();
            DontDestroyOnLoad(t_GameObject);
        }
        return t_Instance;
    }
    private static SoundManagerScript m_Instance;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Instance = EnsureInstance();
    }
    public static void PlaySound(AudioClip p_Sound, Vector2 p_Position)
    {
        GameObject t_AudioPlayer = new GameObject("AudioPlayer");
        AudioSource t_AudioSource = t_AudioPlayer.AddComponent<AudioSource>();
        t_AudioSource.clip = p_Sound;
        t_AudioSource.pitch = Random.Range(0.9f, 1.1f);
        t_AudioSource.Play();
        m_Instance.StartCoroutine(DestroyGameObjectAfterTime(t_AudioPlayer, t_AudioSource.clip.length));
    }
    public static void DestroyGameObject(GameObject p_GameObject, float p_Time = 0f)
    {
        if (p_Time <= 0f)
        {
            Destroy(p_GameObject);
        }
        else
        {
            m_Instance.StartCoroutine(DestroyGameObjectAfterTime(p_GameObject, p_Time));
        }
    }
    private static IEnumerator DestroyGameObjectAfterTime(GameObject p_GameObject, float p_Time)
    {
        yield return new WaitForSeconds(p_Time);
        Destroy(p_GameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
