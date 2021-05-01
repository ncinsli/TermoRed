using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class GroundChecker : MonoBehaviour{
    public bool touchingGround;
    public event Action onTriggerEntered;
    // TODO: земля может быть не любым объектом. но пока, я не очень понимаю, какие объекты не могут быть им
    private void OnTriggerEnter(Collider col){ 
        touchingGround = true;
        if (onTriggerEntered != null) onTriggerEntered.Invoke();
        else Debug.Log("<color=red>[WARNING!]</color> OnTriggerEnteredEvent not set!");
    }
    private void OnTriggerExit(Collider col) => touchingGround = false;
}