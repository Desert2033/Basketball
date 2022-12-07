using UnityEngine;

public class PauseBall : State
{
    private Rigidbody2D _ballRigidbody;

    private State _prevState;

    private Vector2 _ballVelocity;

    public PauseBall(Rigidbody2D ballRigidbody, State prevState)
    {
        _ballRigidbody = ballRigidbody;

        _prevState = prevState;
    }

    public override void Enter()
    {
        _ballVelocity = _ballRigidbody.velocity;

        _ballRigidbody.velocity = Vector2.zero;

        _ballRigidbody.freezeRotation = true;

        _ballRigidbody.isKinematic = true;
    }

    public override void Exit()
    {
        _ballRigidbody.velocity = _ballVelocity;

        _ballRigidbody.isKinematic = false;

        _ballRigidbody.freezeRotation = false;
    }
}
