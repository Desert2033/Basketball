using System;
using UnityEngine;

public class Star : MonoBehaviour
{
    private int _baseAddStar = 1;

    public event Action<int> OnAddStar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            OnAddStar?.Invoke(_baseAddStar);

            gameObject.SetActive(false);
        }
    }
}
