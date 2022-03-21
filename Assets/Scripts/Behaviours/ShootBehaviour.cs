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
        public IBehaviourDependency dependencies => _dependencies;
        private ShootDependencies _dependencies { get; set; }
        private int sleeveCounter = 0;
        private int bulletCounter = 0;

        public void Update()
        {
            if (Input.GetKey(_dependencies.shootKey))
            {
                Debug.Log(_dependencies.animationBehaviour.currentAnimation);

                sleeveCounter++;
                if (sleeveCounter % _dependencies.bulletFrequency != 0) return;
                
                if (_dependencies.stateProvider.state.bulletCount <= 0)
                {
                    _dependencies.animationBehaviour.OnIdle();
                    return;
                }
                _dependencies.stateProvider.SubtractBullets(1);
                
                _dependencies.animationBehaviour.OnShoot();
                var bullet = GameObject.Instantiate(_dependencies.bulletPrefab, _dependencies.bulletSpawnpoint.position, Quaternion.LookRotation(_dependencies.directionCounter.rawForward) * Quaternion.Euler(-90f, 0f, 0f));
                
                if (_dependencies.sleevePrefab)
                {
                    sleeveCounter = ( sleeveCounter + 1 ) % _dependencies.sleeveFrequency;
                    if (sleeveCounter % _dependencies.sleeveFrequency == 0)
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
                _dependencies.stateProvider.Reload();
            }
            
            if (Input.GetKeyUp(_dependencies.reloadKey))
            {
                _dependencies.animationBehaviour.OnIdle();
            }
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            this._dependencies = d as ShootDependencies;

            return this;
        }
    }
}
