using UnityEngine;

public class Menu : MonoBehaviour, IPause
{
    [SerializeField] private GameObject _pausedMenu;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _bulbLight;
    [SerializeField] private GameObject _bulbDark;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _startGame;
    [SerializeField] private GameObject _restartMenu;
    
    [SerializeField] private Camera _mainCamera;


    private GameObject _currentBulb;

    private Color _colorDark;

    private Color _colorLight;

    public void Init()
    {
        ColorUtility.TryParseHtmlString("#2E2E2E", out Color colorDark);
        ColorUtility.TryParseHtmlString("#BEBEBE", out Color colorLight);

        _colorDark = colorDark;
        _colorLight = colorLight;

        _currentBulb = _bulbLight;
    }

    public void MainMenu()
    {
        _score.SetActive(false);
        _pauseButton.SetActive(false);

        _startGame.SetActive(true);
        _currentBulb.SetActive(true);
    }

    public void InGame()
    {
        _score.SetActive(true);
        _pauseButton.SetActive(true);

        _startGame.SetActive(false);
        _currentBulb.SetActive(false);
    }

    public void SetPause()
    {
        _pausedMenu.SetActive(true);
    }

    public void UnPause()
    {
        _pausedMenu.SetActive(false);
    }

    public void RestartMenu()
    {
        _restartMenu.SetActive(true);
    }

    public void ChangeColour()
    {
        _currentBulb.SetActive(false);

        if (_currentBulb == _bulbLight)
        {
            _currentBulb = _bulbDark;

            _mainCamera.backgroundColor = _colorDark;
        }
        else
        {
            _currentBulb = _bulbLight;

            _mainCamera.backgroundColor = _colorLight;
        }

        _currentBulb.SetActive(true);
    }
}
