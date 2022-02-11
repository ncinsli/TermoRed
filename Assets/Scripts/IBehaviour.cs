using UnityEngine;

namespace Definitions
{
    /*
     * Even it is not defined in IBehaviour, every behaviour
     * needs a variable to contain IBehaviourContext, but the type of context
     * is different for every behaviour
     * Of course, I could add IBehaviourContext, but it isn't necessary to access a context
     * for the behaviour
     */

    // Basic behaviour marker
    public interface IBehaviour
    {
        IBehaviour BindDependencies(IBehaviourDependency context);
        IBehaviourDependency dependencies { get; }
    }

    // Something (usually behaviour) that gets updates from game loop
    public interface IUpdateReceiver
    {
        void Update();
    }

    // Something (usually behaviour) that gets collision enter events
    public interface ICollisionEventReceiver
    {
        void OnCollisionEnter(Collision col);
    }

    // Something (usually behaviour) that gets fixed updates from game loop
    public interface IFixedUpdateReceiver
    {
        void FixedUpdate();
    }
}