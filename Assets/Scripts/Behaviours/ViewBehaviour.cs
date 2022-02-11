using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    public class ViewBehaviour : IBehaviour, IUpdateReceiver
    {
        private ViewDependencies _dependencies;
        private bool inActive;
        public void Update()
        {
            if (inActive) return;
            
            _dependencies.currentRotation = _dependencies.transform.eulerAngles;
            _dependencies.currentRotation += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
            _dependencies.transform.rotation = Quaternion.Euler(_dependencies.currentRotation);
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as ViewDependencies;

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