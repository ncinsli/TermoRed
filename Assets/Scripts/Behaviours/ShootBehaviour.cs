using System;
using Definitions;
using ExternalDependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class ShootBehaviour : IBehaviour
    {
        private ShootDependencies _dependencies { get; set; }
        public void FixedUpdate(){}
        private int count = 0;
        
        public void Update()
        {
            if (Input.GetKey(_dependencies.shootKey))
            {
                var bullet = GameObject.Instantiate(_dependencies.bulletPrefab, _dependencies.bulletSpawnpoint.position, Quaternion.LookRotation(_dependencies.directionCounter.rawForward) * Quaternion.Euler(-90f, 0f, 0f));
                _dependencies.onShoot();
                if (_dependencies.sleevePrefab)
                {
                    count = ( count + 1 ) % _dependencies.sleeveFrequency;
                    if (count % _dependencies.sleeveFrequency == 0)
                        GameObject.Instantiate(_dependencies.sleevePrefab, _dependencies.sleeveSpawnpoint.position, _dependencies.realisation.transform.rotation);
                    
                }
                
                var bulletRealisation = bullet.GetComponent<BulletRealisation>();
                if (bulletRealisation == null) Debug.Log("<color=red>NULLREFERENCE</color> bullet prefab doesn't have BulletRealisation attached!");

                bulletRealisation.weaponShooted = _dependencies.realisation as WeaponRealisation;
            }
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            this._dependencies = d as ShootDependencies;
            Debug.Log($"Successfully binded dependency of Shoot Behaviour");
            return this;
        }
    }
}
