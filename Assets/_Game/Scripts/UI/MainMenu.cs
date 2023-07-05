using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject mainMenu;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject indicator;

    public void Play()
    {
        gameManager.SetActive(true);
        mainMenu.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        indicator.SetActive(true);
    }

    public void Weapon()
    {

    }

    public void Skin()
    {

    }
}
