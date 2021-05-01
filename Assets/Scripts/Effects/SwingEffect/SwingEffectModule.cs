using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingEffectModule : MonoBehaviour{
    [SerializeField] private EntityManager entity;
    [SerializeField] private InputHandleModule inputModule;
    private float offset;
    private float val;
    private void Start() => val = Time.deltaTime;
    private void Update(){
        if (!inputModule.moving) return;
        offset += val;
        if (offset > 1f) val = -val;
        if (offset < -1f) val = -val;
        transform.Rotate(0, 0, Mathf.Sin(offset) * 0.02f);
    }
}
