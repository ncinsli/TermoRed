using Behaviours;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Definitions
{
    public abstract class BehaviourRealisation : MonoBehaviour
    {
        public virtual void SetupContainers(params ScriptableObject[] dependencies){}
        /*
         * Implementing some MonoBehaviour functions as methods (not globally)
         */
    }
}