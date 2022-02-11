﻿using Definitions;
using Dependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    public class BulletBehaviour : IBehaviour, ICollisionEventReceiver
    {
        public IBehaviourDependency dependencies => _dependencies;
        private BulletDependencies _dependencies;
        public void OnCollisionEnter(Collision col)
        {
            if (((1 << col.gameObject.layer) & _dependencies.destroyableBy.value) > 0)
            {
                if (_dependencies?.realisation == null) return;
                var r = _dependencies?.realisation as BulletRealisation;
                r.Destroy(0f);
            }
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as BulletDependencies;
            if (_dependencies?.directionCounter)
                _dependencies.rigidbody.velocity = _dependencies.directionCounter.rawForward * _dependencies.speed;

            (_dependencies.realisation as BulletRealisation).Destroy(5f);
            return this;
        }

    }
}