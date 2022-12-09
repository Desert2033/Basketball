using UnityEngine;

public class SpawnerBasket
{
    private Basket _basketFirst;

    private Basket _basketSecond;

    private Basket _currentRespawn;

    public SpawnerBasket(Basket basketFirst, Basket basketSecond)
    {
        _basketFirst = basketFirst;

        _basketSecond = basketSecond;

        _currentRespawn = _basketSecond;
    }

    public void Spawn(int point)
    {
        if (_basketFirst == _currentRespawn)
        {
            _currentRespawn = _basketSecond;
        }
        else
        {
            _currentRespawn = _basketFirst;
        }
        
        _currentRespawn.Refresh();

        RandomPosition(_currentRespawn);
    }

    public void RandomPosition(Basket respawnTarget)
    {
        Vector3 targetPosition = respawnTarget.transform.position;

        Vector3 cameraToObject = targetPosition - Camera.main.transform.position;

        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        float Xleft = leftBot.x;
        float Xright = rightTop.x;

        float Ymin = targetPosition.y + 4f;
        float Ymax = targetPosition.y + 6f;

        float Xmin = targetPosition.x < 0f ? Xleft + 1f : 0f + 2f;
        float Xmax = targetPosition.x > 0f ? Xright - 1f : 0f - 2f;

        float Ynew = Random.Range(Ymin, Ymax);
        float Xnew = Random.Range(Xmin, Xmax);

        respawnTarget.transform.position = new Vector2(Xnew, Ynew);
        respawnTarget.transform.rotation = Quaternion.identity;
    }
}
