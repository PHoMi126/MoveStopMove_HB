using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject mainMenu;
    public GameObject joystick;
    public GameObject pauseButton;
    //public bool isEnabled = false;

    public void Play()
    {
        //isEnabled = !isEnabled;
        gameManager.SetActive(true);
        mainMenu.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void Weapon()
    {

    }

    public void Skin()
    {

    }
}
