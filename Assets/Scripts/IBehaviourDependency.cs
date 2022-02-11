using UnityEngine;

namespace Definitions
{
    public interface IBehaviourDependency
    {
        BehaviourRealisation realisation { get; set; }
    }
}