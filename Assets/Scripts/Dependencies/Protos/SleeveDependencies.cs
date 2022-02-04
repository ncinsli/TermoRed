using Definitions;
using UnityEngine;
using Realisations;

namespace Dependencies
{
    [CreateAssetMenu]
    public class SleeveDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public float lifetime;
    }
}