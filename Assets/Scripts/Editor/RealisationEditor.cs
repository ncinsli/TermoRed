#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Definitions;
using Realisations;

namespace Realisations
{
    [CustomEditor(typeof(BehaviourRealisation), true)]
    public class RealisationEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying){

                GUILayout.Space(30);
                
                GUILayout.BeginHorizontal();
                
                ((BehaviourRealisation)target)?.GetBehaviours().ForEach(b => {
                    GUILayout.Box(new GUIContent{text = b.ToString()});
                });
                
                GUILayout.EndHorizontal();
            }
            
        }
    }
}
#endif