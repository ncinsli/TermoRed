using Contexts;
using Behaviours;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Definitions
{
    public abstract class BehaviourRealisation : MonoBehaviour
    {
        /*
         * Here was the legacy functionality of handling Update() methods of IBehaviours
         * But I decided that it would be better to let every realisation call Update by itself 
         */
    }
}