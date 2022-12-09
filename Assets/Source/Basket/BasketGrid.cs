using UnityEngine;

[RequireComponent(typeof(Animation))]
public class BasketGrid : MonoBehaviour
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Ball ball))
        {
            CollisionWithBall();
        }
    }

    public void CollisionWithBall()
    {
        _animation.Play();
    }
}
