using Contexts;
using Definitions;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    public class BulletBehaviour : IBehaviour
    {
        private BulletBehaviourContext _context;
        
        public void Update()
        {
        }

        public void FixedUpdate()
        {
            
        }


        private void OnCollisionEnter(Collision col)
        {
            _context.gameObject.GetComponent<BulletRealisation>().Destroy();
        }

        public IBehaviour BindContext(IBehaviourContext context)
        {
            _context = context as BulletBehaviourContext;
            _context.onCollision += OnCollisionEnter;
            _context.rigidbody.velocity = _context.directionCounter.forward * 100f;

            return this;
        }

    }
}