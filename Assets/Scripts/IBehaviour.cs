namespace Definitions
{
    /*
     * Even it is not defined in IBehaviour, every behaviour
     * needs a variable to contain IBehaviourContext, but the type of context
     * is different for every behaviour
     * Of course, I could add IBehaviourContext, but it isn't necessary to access a context
     * for the behaviour
     */
    public interface IBehaviour
    {
        void Update();
        void FixedUpdate();
        IBehaviour BindContext(IBehaviourContext context);
    }
}