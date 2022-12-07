using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour, ITargetForce, IPause
{
    private StateMachine _stateMachine;

    private Dictionary<Type, State> _states;

    private Rigidbody2D _ballRigidbody;

    private State _prevState;

    public Vector2 Speed { get; private set; }

    private void StateInit()
    {
        _states = new Dictionary<Type, State>();

        _stateMachine = new StateMachine();

        _states.Add(typeof(IdleBall), new IdleBall(_ballRigidbody));
        _states.Add(typeof(MoveBall), new MoveBall(this));

        _stateMachine.Init(_states[typeof(IdleBall)]);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void Init()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();

        Speed = Vector2.zero;

        StateInit();
    }

    public void Force(Vector2 speed)
    {
        Speed = speed;

        SetState(typeof(MoveBall));
    }

    public Vector3 SimulateForce(Vector3 speed, float timeStamp)
    {
        Vector3 simulatePosition = transform.position + speed * timeStamp + Physics.gravity * timeStamp * timeStamp / 2f;

        simulatePosition.z = 0f;

        return simulatePosition;
    }

    public void SetState(Type newState)
    {
        if (_states.ContainsKey(newState))
            _stateMachine.ChangeState(_states[newState]);
        else
            throw new Exception($"{this} don't have {newState}");
    }

    public void SetPause()
    {
        _prevState = _stateMachine.CurrentState;

        _stateMachine.ChangeState(new PauseBall(_ballRigidbody, _prevState));
    }

    public void UnPause()
    {
        _stateMachine.ChangeState(_prevState);
    }
}
