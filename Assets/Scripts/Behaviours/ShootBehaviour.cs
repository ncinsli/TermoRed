using System;
using Definitions;
using Dependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class ShootBehaviour : IBehaviour, IUpdateReceiver
    {
        private ShootDependencies _dependencies { get; set; }
        private int count = 0;
        private bool inActive;

        public void Update()
        {
            if (inActive) return;
            
            if (Input.GetKey(_dependencies.shootKey))
            {
                _dependencies.animationBehaviour.OnShoot();
                var bullet = GameObject.Instantiate(_dependencies.bulletPrefab, _dependencies.bulletSpawnpoint.position, Quaternion.LookRotation(_dependencies.directionCounter.rawForward) * Quaternion.Euler(-90f, 0f, 0f));
                
                if (_dependencies.sleevePrefab)
                {
                    count = ( count + 1 ) % _dependencies.sleeveFrequency;
                    if (count % _dependencies.sleeveFrequency == 0)
                        GameObject.Instantiate(_dependencies.sleevePrefab, _dependencies.sleeveSpawnpoint.position, _dependencies.realisation.transform.rotation);
                    
                }
                
                var bulletRealisation = bullet.GetComponent<BulletRealisation>();
                if (bulletRealisation == null)
                    Debug.Log("<color=red>NULLREFERENCE</color> bullet prefab doesn't have BulletRealisation attached!");
                bulletRealisation.InjectWeapon(_dependencies.realisation as WeaponRealisation);
            }

            if (Input.GetKeyUp(_dependencies.shootKey))
                _dependencies.animationBehaviour.OnIdle();

            if (Input.GetKeyDown(_dependencies.reloadKey))
            {
                _dependencies.animationBehaviour.OnReload();
            }
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            this._dependencies = d as ShootDependencies;

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
