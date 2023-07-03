using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject pauseButton;

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver()
    {
        pauseButton.SetActive(false);
    }
}
