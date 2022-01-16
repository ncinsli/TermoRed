using Definitions;
using ExternalDependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    public class BulletBehaviour : IBehaviour
    {
        private BulletDependencies _dependencies;
        
        public void Update(){}

        public void FixedUpdate(){}

        public void OnCollisionEnter(Collision col)
        {
            if (((1 << col.gameObject.layer) & _dependencies.destroyableBy.value) > 0)
            {
                if (_dependencies.realisation == null) return;
                var r = _dependencies.realisation as BulletRealisation;
                r.Destroy(0f);
            }
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as BulletDependencies;
            _dependencies.rigidbody.velocity = _dependencies.directionCounter.rawForward * _dependencies.speed;
            Debug.Log($"Successfully binded dependency of Bullet Behaviour");
            (_dependencies.realisation as BulletRealisation).Destroy(5f);
            return this;
        }

    }
}