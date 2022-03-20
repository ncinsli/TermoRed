using GameState;
using States;

namespace Definitions
{
    public interface IBehaviourDependency
    {
        BehaviourRealisation realisation { get; set; }
    }
}