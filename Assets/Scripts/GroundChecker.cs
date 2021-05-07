using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Users
{
    [RequireComponent(typeof(Collider))]
    public class GroundChecker : MonoBehaviour
    {
        public bool touchingGround;

        // TODO: земля может быть не любым объектом. но пока, я не очень понимаю, какие объекты не могут быть им
        private void OnTriggerEnter(Collider col) => touchingGround = true;
        private void OnTriggerStay(Collider col) => touchingGround = true;
        private void OnTriggerExit(Collider col) => touchingGround = false;
    }
}