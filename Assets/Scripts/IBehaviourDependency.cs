using UnityEngine;

namespace Definitions
{
    public interface IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
    }
}