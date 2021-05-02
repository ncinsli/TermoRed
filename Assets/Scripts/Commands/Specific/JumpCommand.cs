namespace Commands.Specific
{
    public struct JumpCommand : ICommand<IJumpContext>
    {
        public void Execute<TContext>(TContext context)
            where TContext : IContext, IJumpContext =>
            context.Jump.Jump();
    }
}