using Realisations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Definitions
{
    public abstract class BehaviourRealisation : MonoBehaviour
    {
        public virtual void SetupContainers(params ScriptableObject[] dependencies){}

        public List<IBehaviour> behaviours { get; protected set; }
        public void DeactivateBehaviour(IBehaviour behaviour) => (behaviours.Find((b) => b.GetType() == behaviour.GetType())).Deactivate();
        public void ActivateBehaviour(IBehaviour behaviour) => (behaviours.Find((b) => b.GetType() == behaviour.GetType())).Activate();
        public void InjectBehaviour(IBehaviour behaviour) => behaviours.Add(behaviour);

        // Update event applied to all behaviours in this realisation that get updates
        protected Action<IUpdateReceiver> onUpdate;
        protected Action<IFixedUpdateReceiver> onFixedUpdate;
        protected Action<ICollisionEventReceiver, Collision> onCollisionEnter;

        private void Update()
        {
            behaviours.ForEach(b => 
            {
                var a = b as IUpdateReceiver;
                if (a == null) return;
                onUpdate?.Invoke(a);
            });
        } 
        private void FixedUpdate()
        {
            behaviours.ForEach(b => 
            {
                var a = b as IFixedUpdateReceiver;
                if (a == null) return;

                onFixedUpdate?.Invoke(a);
            });
        }
        private void OnCollisionEnter(Collision col) => behaviours.ForEach(b => onCollisionEnter?.Invoke(b as ICollisionEventReceiver, col));
        /*
         * Implementing some MonoBehaviour functions as methods (not globally)
         */
    }
}