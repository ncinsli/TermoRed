using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBinder : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 multiplyVector = Vector3.one;
    private void Update()
    {
        float x = target.localEulerAngles.x * multiplyVector.x;
        float y = target.localEulerAngles.y * multiplyVector.y;
        float z = target.localEulerAngles.z * multiplyVector.z;
        transform.eulerAngles = new Vector3(x, y, z);
    }
}
