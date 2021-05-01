using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ViewModule : MonoBehaviour{
    public void Update(){
        float x = -Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(x, y, 0);
    }
}
