public class PauseBasket : State
{
    private State _prevState;

    public PauseBasket(State prevState)
    {
        _prevState = prevState;
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
       
    }
}
