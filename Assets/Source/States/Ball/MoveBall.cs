using UnityEngine;

public class MoveBall : State
{
    private Rigidbody2D _ballRigidbody;

    private Ball _ball;

    public MoveBall(Ball ball)
    {
        _ballRigidbody = ball.GetComponent<Rigidbody2D>();

        _ball = ball;
    }

    public override void Enter()
    {    
        if(_ballRigidbody.velocity == Vector2.zero)
            _ballRigidbody.AddForce(_ball.Speed, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
    }
}
