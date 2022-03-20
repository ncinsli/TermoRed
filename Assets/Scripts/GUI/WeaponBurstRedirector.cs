using States;
using TMPro;
using UnityEngine;

namespace GUI
{
    public class WeaponBurstRedirector : StateGUIRedirector<WeaponStateProvider>
    {
        private void Update() =>
            text.text = stateProvider.state.burstCount.ToString();
    }
}