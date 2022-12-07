using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Trajectory : MonoBehaviour
{
    private LineRenderer _line;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    public void Show(Vector3 speed , ITargetForce targetForce)
    {
        Vector3[] points = new Vector3[10];

        _line.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float timeStamp = i * 0.1f;

            points[i] = targetForce.SimulateForce(speed, timeStamp);
        }

        _line.SetPositions(points);
    }

    public void Hide()
    {
        _line.positionCount = 0;
    }
}
