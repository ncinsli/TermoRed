using UnityEngine;

namespace Commands.Specific
{
    public struct MovementCommand : ICommand<IMovementContext>
    {
        public readonly Vector3 Direction;

        public MovementCommand(Vector3 direction)
        {
            Direction = direction;
        }

        public void Execute<TContext>(TContext context)
            where TContext : IContext, IMovementContext =>
            context.Movement.Move(Direction);
    }
}