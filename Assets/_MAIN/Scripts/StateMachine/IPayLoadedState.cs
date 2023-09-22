public interface IPayLoadedState<in T> : IExitState
{
    public void Enter(T payload);
}