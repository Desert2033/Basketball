using UnityEngine;

public class AimingBasket : State
{
    private Basket _basket;

    private InputMouseDrag _mouseDrag;

    private Trajectory _lineTrajectory;

    private ITargetForce _targetForce;

    private Vector3 _speed;

    private float _powerHit;
    private float _minPowerHit = 2f;

    public AimingBasket(Basket basket, Trajectory lineTrajectory)
    {
        _mouseDrag = new InputMouseDrag();

        _basket = basket;

        _targetForce = _basket.TargetForce;

        _lineTrajectory = lineTrajectory;

        _speed = Vector3.zero;
    }

    private void Rotate(Vector2 direction)
    {
        float angle = Mathf.Atan2(_mouseDrag.Direction.x, _mouseDrag.Direction.y) * Mathf.Rad2Deg;

        _basket.transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }

    public override void Enter()
    {
        _basket.transform.rotation = Quaternion.identity;

        _mouseDrag.OnEndDrag += OnDragEnd;
        _mouseDrag.OnDragging += OnDragging;

        _lineTrajectory.Hide();
    }

    public override void Exit()
    {
        _mouseDrag.OnEndDrag -= OnDragEnd;
        _mouseDrag.OnDragging -= OnDragging;

        _lineTrajectory.Hide();
    }

    public override void Update()
    {
        base.Update();
        
        _mouseDrag.Update();
    }

    public void OnDragging()
    {
        _powerHit = _mouseDrag.Distance;

        if (_minPowerHit <= _powerHit)
        {
            _speed = _powerHit * (Vector3)_mouseDrag.Direction;

            _lineTrajectory.Show(_speed, _targetForce);
        }

        Rotate(_mouseDrag.Direction);
    }

    public void OnDragEnd()
    {
        _basket.SetState(typeof(IdleBasket));

        _targetForce.Force(_speed);
    }
}
