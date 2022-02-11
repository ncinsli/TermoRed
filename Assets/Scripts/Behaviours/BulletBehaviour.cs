using Definitions;
using Dependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    public class BulletBehaviour : IBehaviour, ICollisionEventReceiver
    {
        private BulletDependencies _dependencies;
        private bool inActive;

        public void OnCollisionEnter(Collision col)
        {
            if (inActive) return;

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

        public IBehaviour Deactivate()
        {
            inActive = true;
            return this;
        }

        public IBehaviour Activate()
        {
            inActive = false;
            return this;
        }

    }
}