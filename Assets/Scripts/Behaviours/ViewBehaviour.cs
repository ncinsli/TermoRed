using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Modules
{
    public class ViewBehaviour : IBehaviour
    {
        private ViewDependencies _dependencies;
        
        public void FixedUpdate(){}

        public void Update()
        {
            _dependencies.currentRotation = _dependencies.transform.eulerAngles;
            _dependencies.currentRotation += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
            _dependencies.transform.rotation = Quaternion.Euler(_dependencies.currentRotation);
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as ViewDependencies;
            Debug.Log($"Successfully binded dependency of View Behaviour");
            return this;
        }
    }
}