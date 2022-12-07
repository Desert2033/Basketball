using UnityEngine;
using System;

public class Point : MonoBehaviour
{
    private int _basePoints = 1;

    private bool _isGoal = false;

    public event Action<int, Ball> OnGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            if(!_isGoal)
               Goal(ball);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            _isGoal = _isGoal ? false : _isGoal;
        }
    }

    private void Goal(Ball ball)
    {
        _isGoal = true;

        OnGoal?.Invoke(_basePoints, ball);
    }
}
