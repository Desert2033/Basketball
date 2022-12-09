using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    [SerializeField] private float _YoffsetMax;

    [SerializeField] private float _YoffsetMin;

    private Transform _targetFollow;

    private Vector3 newVector;

    private void Start()
    {
        newVector = transform.position;
    }

    private void Update()
    {
        if (_targetFollow != null)
        {
            float minY = transform.position.y - _YoffsetMin;

            float maxY = transform.position.y + _YoffsetMax;

            if (_targetFollow.position.y <= minY)
                newVector.y = _targetFollow.position.y + _YoffsetMin;
            else if (_targetFollow.position.y >= maxY)
                newVector.y = _targetFollow.position.y - _YoffsetMax;

            transform.position = newVector;
        }
    }

    public void Init(Transform targetFollow)
    {
        _targetFollow = targetFollow;
    }

    public void RemoveTargetFollow()
    {
        _targetFollow = null;
    }
}
