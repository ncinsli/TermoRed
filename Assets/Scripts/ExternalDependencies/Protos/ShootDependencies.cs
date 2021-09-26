using Modules;
using UnityEngine;
using UnityEngine.VFX;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class ShootDependencies : ScriptableObject
    {
        public KeyCode shootKey;
        public GameObject bulletPrefab;
        public VisualEffect smokeEffect;
        public GameObject gameObject;
    }
}