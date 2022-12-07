using UnityEngine;
using System;

public class Level : MonoBehaviour, IPause
{
    [SerializeField] private Basket _basketFirst;

    [SerializeField] private Basket _basketSecond;

    [SerializeField] private Ball _ball;

    [SerializeField] private ScoreView _score;

    [SerializeField] private Menu _menu;

    private SpawnerBasket _spawnerBasket;

    public event Action OnPaused;

    public event Action OnUnpaused;

    private void OnDisable()
    {
        _basketFirst.OnGoal -= _score.AddPoins;

        OnPaused -= _basketFirst.SetPause;
        OnPaused -= _basketSecond.SetPause;
        OnPaused -= _ball.SetPause;
        OnPaused -= _menu.SetPause;

        OnUnpaused -= _basketFirst.UnPause;
        OnUnpaused -= _basketSecond.UnPause;
        OnUnpaused -= _ball.UnPause;
        OnUnpaused -= _menu.UnPause;
    }

    private void OnEnable()
    {
        _menu.MainMenu();

        InitGame();
    }

    private void InitGame()
    {
        _ball.Init();

        _basketFirst.Init(_ball, true);

        _basketSecond.Init(_ball);

        _score.Init(0);

        _basketFirst.OnGoal += _score.AddPoins;
        _basketSecond.OnGoal += _score.AddPoins;

        OnPaused += _basketFirst.SetPause;
        OnPaused += _basketSecond.SetPause;
        OnPaused += _ball.SetPause;
        OnPaused += _menu.SetPause;

        OnUnpaused += _basketFirst.UnPause;
        OnUnpaused += _basketSecond.UnPause;
        OnUnpaused += _ball.UnPause;
        OnUnpaused += _menu.UnPause;

        _spawnerBasket = new SpawnerBasket(_basketFirst, _basketSecond);
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
}
