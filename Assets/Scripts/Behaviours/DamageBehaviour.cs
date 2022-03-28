using System;
using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    public class DamageBehaviour : IBehaviour
    {
        public IBehaviourDependency dependencies { get; }
        private DamageDependencies _dependencies;

        public void TakeDamage(int damage)
        {
            if (damage <= 0) throw new Exception("Damage is <= 0");
            _dependencies.health = Mathf.Clamp(_dependencies.health - damage, 0, _dependencies.health);
        }

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {
            _dependencies = context as DamageDependencies;
            return this;
        }

    }
}