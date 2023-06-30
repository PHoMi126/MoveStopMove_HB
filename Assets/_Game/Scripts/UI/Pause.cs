using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject joystick;

    public void PauseFunc()
    {
        pauseMenu.SetActive(true);
        joystick.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeFunc()
    {
        pauseMenu.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
