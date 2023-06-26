using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject _gameManager;
    public GameObject _mainMenu;
    public GameObject _joystick;
    //public bool isEnabled = false;

    public void Play()
    {
        //isEnabled = !isEnabled;
        _gameManager.SetActive(true);
        _mainMenu.SetActive(false);
        _joystick.SetActive(true);
    }

    public void Weapon()
    {

    }

    public void Skin()
    {

    }
}
