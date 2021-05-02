namespace Commands
{
    public interface ICommand<TConcreteContext>
        where TConcreteContext : IContext
    {
        void Execute<TContext>(TContext content) where TContext : IContext, TConcreteContext;
    }
}