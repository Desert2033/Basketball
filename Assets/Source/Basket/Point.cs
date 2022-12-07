using UnityEngine;
using System;

public class Point : MonoBehaviour
{
    private int _basePoints = 1;

    public event Action<int> OnGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {   
            Goal();

            transform.gameObject.SetActive(false);
        }
    }

    private void Goal()
    {
        OnGoal?.Invoke(_basePoints);
    }
}
