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
    
}
