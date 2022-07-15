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

        private void Shoot()
        {
            var ray = new Ray(_dependencies.bulletSpawnpoint.position, _dependencies.directionCounter.rawForward);
            var hit = new RaycastHit();
            
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rigidbody;
                Debug.Log("Shoot to " + hit.transform.gameObject.name);
                hit.transform.TryGetComponent<Rigidbody>(out rigidbody);
                rigidbody?.AddForceAtPosition(_dependencies.directionCounter.rawForward * 100f, hit.point);
                
                
                var gameObject = hit.transform.gameObject;
                //GameObject.Destroy(gameObject);
                gameObject.GetComponent<BehaviourRealisation>()?.TryGetBehaviour<DamageBehaviour>()?.TakeDamage(1);
                var decalPrefab = GameObject.Instantiate(_dependencies.decal);
                decalPrefab.transform.position = hit.point;
                decalPrefab.transform.rotation = Quaternion.LookRotation(hit.normal);
                decalPrefab.transform.localScale = Vector3.one * 0.1f;
                decalPrefab.transform.SetParent(gameObject.transform);
                
                Debug.Log(hit.transform);
            }
            
            if (_dependencies.sleevePrefab)
            {
                sleeveCounter = ( sleeveCounter + 1 ) % _dependencies.sleeveFrequency;
                if (sleeveCounter % _dependencies.sleeveFrequency == 0)
                    GameObject.Instantiate(_dependencies.sleevePrefab, _dependencies.sleeveSpawnpoint.position, _dependencies.realisation.transform.rotation);
            }
        }
        
        public void Update()
        {
            if (Input.GetKey(_dependencies.shootKey))
            {
                bulletCounter++;
                if (bulletCounter % _dependencies.bulletFrequency != 0)
                {
                    return;
                }
                
                if (_dependencies.stateProvider.state.bulletCount <= 0)
                {
                    _dependencies.animationBehaviour.OnIdle();
                    return;
                }
                _dependencies.stateProvider.SubtractBullets(1);
                
                _dependencies.animationBehaviour.OnShoot();
                Shoot();
            }

            if (Input.GetKeyUp(_dependencies.shootKey))
                _dependencies.animationBehaviour.OnIdle();

            if (Input.GetKeyDown(_dependencies.reloadKey))
            {
                _dependencies.animationBehaviour.OnReload();
                _dependencies.stateProvider.Reload();
            }
            
            if (Input.GetKeyUp(_dependencies.reloadKey))
                _dependencies.animationBehaviour.OnIdle();
            
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            this._dependencies = d as ShootDependencies;

            return this;
        }
    }
}
