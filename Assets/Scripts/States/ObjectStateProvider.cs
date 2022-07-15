using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace GameState
{
    // An abstract class containing json file and basic (De)Serialization methods
    [System.Serializable]
    public abstract class ObjectStateProvider<T> : MonoBehaviour where T : new()
    {
        [SerializeField] private string _stateFileName;
        protected string stateFileName
        {
            get => _stateFileName;
            set => _stateFileName = value;
        }

        public T state { get; protected set; }
        
        private void Awake() => state = Deserialize();

        private void OnDestroy() => Save();
        
        public void Serialize(T obj)
        {
            var text = JsonUtility.ToJson(obj);
            Debug.Log(Application.persistentDataPath + $"/{stateFileName}.json");
            File.WriteAllText(Application.persistentDataPath + $"/{stateFileName}.json", text);
        }

        public T Deserialize()
        {
            string jsonFromDrive;
            if (!File.Exists(Application.persistentDataPath + $"/{stateFileName}.json"))
            {
                Serialize(new T());
                jsonFromDrive = File.ReadAllText(Application.persistentDataPath + $"/{stateFileName}.json");
            }
            else 
                jsonFromDrive = File.ReadAllText(Application.persistentDataPath + $"/{stateFileName}.json");
            
            return JsonUtility.FromJson<T>(jsonFromDrive);
        }

        public void Save() => Serialize(state);
    }
}

