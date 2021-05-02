namespace Commands
{
    public interface IJumpContext : IContext
    {
        JumpModule Jump { get; }
    }
}