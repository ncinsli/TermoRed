using Contexts;
using UnityEngine;

namespace Modules
{
    public class ViewBehaviour
    {
        private ViewBehaviourContext _context;
        
        public void Update()
        {
            _context.currentRotation = _context.transform.eulerAngles;
            _context.currentRotation += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
            _context.transform.rotation = Quaternion.Euler(_context.currentRotation);
        }

        public void BindContext(ViewBehaviourContext context) => this._context = context;
    }
}