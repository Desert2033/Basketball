using System;
using UnityEngine;

public class EndGameSystem : MonoBehaviour
{
    private Transform _basketFirstTransform;
    private Transform _basketSecondTransform;
    private Transform _ballTransform;

    private float Yoffset = 4f;

    public event Action OnGameEnd;

    private void Update()
    {
        float Yball = _ballTransform.position.y;
        float YbasketFirst = _basketFirstTransform.position.y - Yoffset;
        float YbasketSecond = _basketSecondTransform.position.y - Yoffset;

        if (Yball < YbasketFirst && Yball < YbasketSecond)
        {
            OnGameEnd?.Invoke();
        }
    }

    public void Init(Transform ballTransform, Transform basketFirstTransform, Transform basketSecondTransform)
    {
        _basketFirstTransform = basketFirstTransform;

        _basketSecondTransform = basketSecondTransform;

        _ballTransform = ballTransform;
    }
}
