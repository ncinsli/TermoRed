using Contexts;
using Definitions;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class ShootBehaviour : IBehaviour
    {
        private ShootBehaviourContext _context { get; set; }

        public void FixedUpdate(){}
        public void Update()
        {
            if (Input.GetKey(_context.externalDependencies.shootKey))
            {
                var bullet = GameObject.Instantiate(_context.externalDependencies.bulletPrefab, _context.gameObject.transform.position + _context.directionCounter.rawForward, 
                    Quaternion.LookRotation(_context.directionCounter.rawForward) * Quaternion.Euler(90f, 0f, 0f));
                
                var bulletRealisation = bullet.GetComponent<BulletRealisation>();
                if (bulletRealisation == null) Debug.Log("<color=red>NULLREFERENCE</color> bullet prefab doesn't have BulletRealisation attached!");

                bulletRealisation.weaponShooted = _context.weaponRealisation; 
            }
        }

        public IBehaviour BindContext(IBehaviourContext context)
        {
            this._context = context as ShootBehaviourContext;
            Debug.Log($"Successfully binded context of Shoot Behaviour");
            return this;
        }
    }
}
