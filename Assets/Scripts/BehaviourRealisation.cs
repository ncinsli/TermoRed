using Realisations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Definitions
{
    public abstract class BehaviourRealisation : MonoBehaviour
    {
        public virtual List<IBehaviour> GetBehaviours(){
            Debug.LogWarning("No GetBehaviours() realisation! Behaviours attached to script would not be showed!");
            return new List<IBehaviour>();
        }
        public virtual void SetupContainers(params ScriptableObject[] dependencies){}
        /*
         * Implementing some MonoBehaviour functions as methods (not globally)
         */
    }
}