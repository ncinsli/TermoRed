using States;
using TMPro;

namespace GUI
{
    public class WeaponBulletRedirector : StateGUIRedirector<WeaponStateProvider>
    {
        private void Update() => 
            text.text = stateProvider.state.bulletCount.ToString();
    }
}