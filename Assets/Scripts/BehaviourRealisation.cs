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
        public void EjectBehaviour(IBehaviour behaviour) => behaviours.Remove(behaviours.Find((b) => b.GetType() == behaviour.GetType()));
        public void InjectBehaviour(IBehaviour behaviour) => behaviours.Add(behaviour);

        public T TryGetBehaviour<T>() where T : class, IBehaviour
        {
            T result = null;
            behaviours.ForEach(b =>
            {
                if (b.GetType() == typeof(T)) result = b as T;
            });
            return result;
        }
        
        public T TryGetDependency<T>() where T : class, IBehaviourDependency
        {
            T result = null;
            behaviours.ForEach(b => 
            {
                var d = b.dependencies as T;
                if (d != null) result = d;
            });
            return result;
        }

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
                a.Update();
                onUpdate?.Invoke(a);
            });
        } 
        private void FixedUpdate()
        {
            behaviours.ForEach(b => 
            {
                var a = b as IFixedUpdateReceiver;
                if (a == null) return;
                a?.FixedUpdate();
                onFixedUpdate?.Invoke(a);
            });
        }
        private void OnCollisionEnter(Collision col) => 
            behaviours.ForEach(b =>
            {
                (b as ICollisionEventReceiver)?.OnCollisionEnter(col);
                onCollisionEnter?.Invoke(b as ICollisionEventReceiver, col);
            });
        /*
         * Implementing some MonoBehaviour functions as methods (not globally)
         */
    }
}