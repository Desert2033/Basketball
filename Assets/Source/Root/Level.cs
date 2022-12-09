using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour, IPause
{
    [SerializeField] private Basket _basketFirst;

    [SerializeField] private Basket _basketSecond;

    [SerializeField] private Ball _ball;

    [SerializeField] private ScoreView _scorePoints;

    [SerializeField] private ScoreView _scoreStars;

    [SerializeField] private Menu _menu;

    [SerializeField] private CameraFollow _mainCamera;

    [SerializeField] private EndGameSystem _endGameSystem;

    private SpawnerBasket _spawnerBasket;

    public event Action OnPaused;

    public event Action OnUnpaused;

    private void OnDisable()
    {
        _basketFirst.Point.OnGoal -= _scorePoints.AddPoins;
        _basketFirst.Point.OnGoal -= _spawnerBasket.Spawn;
        _basketFirst.Star.OnAddStar -= _scoreStars.AddPoins;

        _basketSecond.Point.OnGoal -= _scorePoints.AddPoins;
        _basketSecond.Point.OnGoal -= _spawnerBasket.Spawn;
        _basketSecond.Star.OnAddStar += _scoreStars.AddPoins;

        OnPaused -= _basketFirst.SetPause;
        OnPaused -= _basketSecond.SetPause;
        OnPaused -= _ball.SetPause;
        OnPaused -= _menu.SetPause;

        OnUnpaused -= _basketFirst.UnPause;
        OnUnpaused -= _basketSecond.UnPause;
        OnUnpaused -= _ball.UnPause;
        OnUnpaused -= _menu.UnPause;

        _endGameSystem.OnGameEnd -= _mainCamera.RemoveTargetFollow;
        _endGameSystem.OnGameEnd -= _menu.RestartMenu;
        _endGameSystem.OnGameEnd -= _ball.SetPause;
    }

    private void OnEnable()
    {
        _menu.Init();

        _menu.MainMenu();

        InitGame();
    }

    private void InitGame()
    {
        _ball.Init();

        _basketFirst.Init(_ball);

        _basketSecond.Init(_ball);

        _scorePoints.Init(0);

        _scoreStars.Init(0);

        _mainCamera.Init(_ball.transform);

        _endGameSystem.Init(_ball.transform, _basketFirst.transform, _basketSecond.transform);

        _spawnerBasket = new SpawnerBasket(_basketFirst, _basketSecond);

        _basketFirst.Point.OnGoal += _scorePoints.AddPoins;
        _basketFirst.Point.OnGoal += _spawnerBasket.Spawn;
        _basketFirst.Star.OnAddStar += _scoreStars.AddPoins;

        _basketSecond.Point.OnGoal += _scorePoints.AddPoins;
        _basketSecond.Point.OnGoal += _spawnerBasket.Spawn;
        _basketSecond.Star.OnAddStar += _scoreStars.AddPoins;


        OnPaused += _basketFirst.SetPause;
        OnPaused += _basketSecond.SetPause;
        OnPaused += _ball.SetPause;
        OnPaused += _menu.SetPause;

        OnUnpaused += _basketFirst.UnPause;
        OnUnpaused += _basketSecond.UnPause;
        OnUnpaused += _ball.UnPause;
        OnUnpaused += _menu.UnPause;

        _endGameSystem.OnGameEnd += _mainCamera.RemoveTargetFollow;
        _endGameSystem.OnGameEnd += _menu.RestartMenu;
        _endGameSystem.OnGameEnd += _ball.SetPause;
    }

    public void StartMenu()
    {
        _menu.MainMenu();
    }

    public void StartGame()
    {
        _menu.InGame();

        _ball.SetState(typeof(MoveBall));
    }

    public void SetPause()
    {
        OnPaused?.Invoke();
    }

    public void UnPause()
    {
        OnUnpaused?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
