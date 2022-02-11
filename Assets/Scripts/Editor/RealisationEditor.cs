// #if UNITY_EDITOR
// using UnityEditor;
// using UnityEngine;
// using Definitions;
// using Realisations;
// using Dependencies;

// namespace Realisations
// {
//     [CustomEditor(typeof(BehaviourRealisation), true)]
//     public class RealisationEditor : Editor
//     {
//         public override void OnInspectorGUI()
//         {
//             base.OnInspectorGUI();

//             // if (Application.isPlaying){

//                 GUILayout.Space(30);
                
                
//                 ((BehaviourRealisation)target)?.behaviours.ForEach(b => 
//                 {
//                     GUILayout.BeginHorizontal();
                  
//                     GUILayout.Box(new GUIContent{text = "A"});
                    
//                     var count = 0;
//                     var buttonContent = new GUIContent{text = $"Disable {b.ToString()}"};
//                     if (GUILayout.Button(buttonContent))
//                     {
//                         if (count % 2 ==0)
//                         {
//                             ((BehaviourRealisation)target)?.InjectBehaviour(b);
//                             buttonContent.text = $"Disable {b.ToString()}";
//                         }
//                         else
//                         {
//                             (target as BehaviourRealisation).DeactivateBehaviour(b);
//                             buttonContent.text = $"Enable {b.ToString()}";
//                         }
//                         count++;
//                     }

//                     GUILayout.EndHorizontal();
//                 });
            
//             // }
            
//         }
//     }
// }
// #endif