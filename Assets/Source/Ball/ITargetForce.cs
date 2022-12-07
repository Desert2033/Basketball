using UnityEngine;

public interface ITargetForce
{ 
    public void Force(Vector2 speed);

    public Vector3 SimulateForce(Vector3 speed, float timeStamp);
}
