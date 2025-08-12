using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int HP = 5;

    public int WINBRKCOUNT;
    public void GameOver()
    {
        HP--;

        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }
    public void Victory()
    {
        if (WINBRKCOUNT <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    public void ResetLevel()
    {
        Object.FindFirstObjectByType<BallScript>().ResBall();
        Object.FindFirstObjectByType<PlayerBoardScript>().ResPly();
    }
    public void Update()
    {
        Victory();
    }

    private static IEnumerator ShakeCamera(Camera camera, float duration, float magnitude)
    {
        Vector3 originalPosition = camera.transform.localPosition;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        camera.transform.localPosition = originalPosition;
    }
    
}
