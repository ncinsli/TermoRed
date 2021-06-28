using System;
using UnityEngine;
using System.Collections;
using Settings;
using Definitions;

namespace Contexts
{
    public class ShootBehaviourContext : IBehaviourContext
    {
        public GameObject gameObject;
        public ShootBehaviourSettings settings;
        public DirectionCounter directionCounter;
        public WeaponRealisation weaponRealisation;
        public ShootBehaviourContext(GameObject obj, ShootBehaviourSettings settings)
        {
            gameObject = obj;
            this.settings = settings;
        }
    }
}