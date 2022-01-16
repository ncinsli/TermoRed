using Definitions;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class SleeveDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public float lifetime;
    }
}