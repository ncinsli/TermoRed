using System;
using Contexts;
using Modules;
using Settings;
using UnityEngine;

namespace Realisations
{
    public class PlayerHeadRealisation : MonoBehaviour
    {
        private ViewBehaviour _viewBehaviour;
        [SerializeField] private ViewBehaviourContext _viewBehaviourContext;
        public ViewBehaviourSettings _viewBehaviourSettings;

        private void Start()
        {
            _viewBehaviourContext = new ViewBehaviourContext(gameObject, _viewBehaviourSettings);
            _viewBehaviour = new ViewBehaviour();
            _viewBehaviour.BindContext(_viewBehaviourContext);
        }

        private void Update()
        {
            _viewBehaviour.Update();
        }
    }
}