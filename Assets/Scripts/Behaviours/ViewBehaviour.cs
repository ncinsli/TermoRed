using Contexts;
using Definitions;
using UnityEngine;

namespace Modules
{
    public class ViewBehaviour : IBehaviour
    {
        private ViewBehaviourContext _context;
        
        public void FixedUpdate(){}

        public void Update()
        {
            _context.currentRotation = _context.transform.eulerAngles;
            _context.currentRotation += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
            _context.transform.rotation = Quaternion.Euler(_context.currentRotation);
        }

        public IBehaviour BindContext(IBehaviourContext context)
        {
            _context = context as ViewBehaviourContext;
            return this;
        }
    }
}