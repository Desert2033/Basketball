using UnityEngine;

public class Menu : MonoBehaviour, IPause
{
    [SerializeField] private GameObject _pausedMenu;

    [SerializeField] private GameObject _score;

    [SerializeField] private GameObject _bulb;

    [SerializeField] private GameObject _settings;

    [SerializeField] private GameObject _pauseButton;

    [SerializeField] private GameObject _startGame;

    public void MainMenu()
    {
        _score.SetActive(false);

        _pauseButton.SetActive(false);

        _startGame.SetActive(true);

        _bulb.SetActive(true);

        _settings.SetActive(true);
    }

    public void InGame()
    {
        _score.SetActive(true);

        _pauseButton.SetActive(true);

        _startGame.SetActive(false);
            
        _bulb.SetActive(false);

        _settings.SetActive(false);
    }

    public void SetPause()
    {
        _pausedMenu.SetActive(true);
    }

    public void UnPause()
    {
        _pausedMenu.SetActive(false);
    }
}
