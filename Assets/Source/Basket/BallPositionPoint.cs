using UnityEngine;
using System;

public class BallPositionPoint : MonoBehaviour
{
    public Action<Ball> OnGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            OnGoal?.Invoke(ball);
        }
    }
}
