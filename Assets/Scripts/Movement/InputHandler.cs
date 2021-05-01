using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EntityManager))]
public class InputHandleModule : MonoBehaviour{
    [SerializeField] private List<KeyCode> keyCodes = new List<KeyCode>();
    
}
