using UnityEngine;

public class IdleBasket : State
{
    private Basket _basket;

    public IdleBasket(Basket basket)
    {
        _basket = basket;
    }

    public override void Enter()
    {
        _basket.transform.rotation = Quaternion.identity;
    }

    public override void Exit()
    {
    }
}
