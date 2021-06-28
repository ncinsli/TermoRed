using System;
using Behaviours;
using Contexts;
using UnityEngine;

namespace Realisations
{
    public class BulletRealisation : MonoBehaviour
    {
        [SerializeField] private BulletBehaviourContext _bulletBehaviourContext;
        private BulletBehaviour _bulletBehaviour;
        public WeaponRealisation weaponShooted { get; set; }
        private void Start()
        {
            _bulletBehaviourContext = new BulletBehaviourContext(gameObject);
            _bulletBehaviourContext.directionCounter = weaponShooted.directionCounter;
            _bulletBehaviour = new BulletBehaviour().BindContext(_bulletBehaviourContext) as BulletBehaviour;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _bulletBehaviourContext.onCollision?.Invoke(collision);
        }
        
        public void Destroy() => Destroy(gameObject);
    }
}