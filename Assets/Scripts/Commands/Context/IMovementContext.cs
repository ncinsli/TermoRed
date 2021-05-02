namespace Commands
{
    public interface IMovementContext : IContext
    {
        MoveModule Movement { get; }
    }
}