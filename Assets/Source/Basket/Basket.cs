using System.Collections.Generic;
using UnityEngine;
using System;

public class Basket : MonoBehaviour, IPause
{
    [SerializeField] private Trajectory _lineTrajectory;

    [SerializeField] private Point _point;

    [SerializeField] private BallPositionPoint _ballPositionPoint;

    private StateMachine _stateMachine;

    private Dictionary<Type, State> _states;

    private State _prevState;

    public Point Point => _point;

    public ITargetForce TargetForce { get; private set; }

    private void OnEnable()
    {
        _ballPositionPoint.OnGoal += SetBallPosition;
    }

    private void OnDisable()
    {
        _ballPositionPoint.OnGoal -= SetBallPosition;
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    private void StateInit()
    {
        _states = new Dictionary<Type, State>();

        _stateMachine = new StateMachine();

        _states.Add(typeof(IdleBasket), new IdleBasket());
        _states.Add(typeof(AimingBasket), new AimingBasket(this, _lineTrajectory));

        _stateMachine.Init(_states[typeof(IdleBasket)]);
    }

    public void Init(ITargetForce targetForce)
    {
        TargetForce = targetForce;

        StateInit();
    }

    public void Refresh()
    {
        _stateMachine.Init(_states[typeof(IdleBasket)]);

        _point.gameObject.SetActive(true);
    }

    public void SetState(Type newState)
    {
        if (_states.ContainsKey(newState)) 
            _stateMachine.ChangeState(_states[newState]);
        else 
            throw new Exception($"{this} don't have {newState}");
    }

    public void SetBallPosition(Ball ball)
    {
        ball.transform.position = _ballPositionPoint.transform.position;

        ball.transform.parent = this.transform;

        ball.SetState(typeof(IdleBall));

        SetState(typeof(AimingBasket));            
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
