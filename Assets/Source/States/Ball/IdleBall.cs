using UnityEngine;

public class IdleBall : State
{
    private Rigidbody2D _ballRigidbody;

    public IdleBall(Rigidbody2D ballRigidbody)
    {
        _ballRigidbody = ballRigidbody;
    }

    public override void Enter()
    {
        _ballRigidbody.velocity = Vector2.zero;

        _ballRigidbody.freezeRotation = true;

        _ballRigidbody.isKinematic = true;
    }

    public override void Exit()
    {
        _ballRigidbody.isKinematic = false;

        _ballRigidbody.freezeRotation = false;
    }
}
