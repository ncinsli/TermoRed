using Modules;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class ShootBehaviourSettings : ScriptableObject
    {
        public KeyCode shootKey;
        public GameObject bulletPrefab;
    }
}