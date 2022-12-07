using UnityEngine;
using System;

public class InputMouseDrag
{
    private Camera _camera => Camera.main;

    private Vector2 _mouseStartPosition;
    private Vector2 _mouseEndPosition;

    private bool _isDragStart => Input.GetMouseButtonDown(0);
    private bool _isDragEnd => Input.GetMouseButtonUp(0);
    private bool _isDragging = false;

    public Vector2 Direction { get; private set; }

    public float Distance { get; private set; }

    public event Action OnDragStart;

    public event Action OnDragging;

    public event Action OnEndDrag;

    public InputMouseDrag()
    {
        Direction = Vector2.zero;

        Distance = 0f;
    }
    
    public void Update()
    {
        if (_isDragEnd)
        {
            _isDragging = false;

            OnEndDrag?.Invoke();
        }
        else if (_isDragStart)
        {
            _mouseStartPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            _isDragging = true;

            OnDragStart?.Invoke();
        }
        
        if (_isDragging)
        {
            _mouseEndPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            Distance = Vector2.Distance(_mouseStartPosition, _mouseEndPosition);

            Direction = (_mouseStartPosition - _mouseEndPosition).normalized;

            OnDragging?.Invoke();
        }
    } 
}
