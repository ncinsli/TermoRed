using System.Collections;
using System.Collections.Generic;
using GameState;
using States;
using TMPro;
using UnityEngine;

namespace GUI
{
    [System.Serializable]
    public abstract class StateGUIRedirector<T> : MonoBehaviour
    {
        [SerializeField] private T _stateProvider;
        protected TMP_Text text;
        protected T stateProvider => _stateProvider;
        private void Awake() => text = GetComponent<TMP_Text>();
    }
}
