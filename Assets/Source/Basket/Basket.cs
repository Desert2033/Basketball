using System.Collections.Generic;
using UnityEngine;
using System;

public class Basket : MonoBehaviour, IPause
{
    [SerializeField] private Trajectory _lineTrajectory;

    [SerializeField] private Point _point;

    private StateMachine _stateMachine;

    private Dictionary<Type, State> _states;

    private State _prevState;

    private bool _isGoal = false;

    public bool IsGoal => _isGoal;

    public ITargetForce TargetForce { get; private set; }

    public event Action<int> OnGoal;

    private void OnEnable()
    {
        _point.OnGoal += Goal;
    }

    private void OnDisable()
    {
        _point.OnGoal -= Goal;
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    private void StateInit()
    {
        _states = new Dictionary<Type, State>();

        _stateMachine = new StateMachine();

        _states.Add(typeof(IdleBasket), new IdleBasket(this));
        _states.Add(typeof(AimingBasket), new AimingBasket(this, _lineTrajectory));

        _stateMachine.Init(_states[typeof(IdleBasket)]);
    }

    public void Init(ITargetForce targetForce, bool isFirstBasket = false)
    {
        TargetForce = targetForce;

        StateInit();

        if (isFirstBasket)
            _isGoal = true;
    }

    public void Refresh()
    {
        _stateMachine.Init(_states[typeof(IdleBasket)]);

        _isGoal = false;
    }

    public void SetState(Type newState)
    {
        if (_states.ContainsKey(newState)) 
            _stateMachine.ChangeState(_states[newState]);
        else 
            throw new Exception($"{this} don't have {newState}");
    }

    public void Goal(int points, Ball ball)
    {
        ball.transform.position = _point.transform.position;

        ball.transform.parent = this.transform;

        ball.SetState(typeof(IdleBall));

        SetState(typeof(AimingBasket));

        if (!_isGoal)
        {
            _isGoal = true;

            OnGoal?.Invoke(points);
        }
    }

    public void SetPause()
    {
        _prevState = _stateMachine.CurrentState;

        _stateMachine.ChangeState(new PauseBasket(_prevState));
    }

    public void UnPause()
    {
        _stateMachine.ChangeState(_prevState);
    }
}
