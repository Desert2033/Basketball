using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetFollow;

    [SerializeField] private float _YoffsetMax;

    [SerializeField] private float _YoffsetMin;

    private Vector3 newVector;

    private void Start()
    {
        newVector = transform.position;
    }

    private void Update()
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
