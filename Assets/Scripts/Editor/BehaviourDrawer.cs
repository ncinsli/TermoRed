// #if UNITY_EDITOR
// using UnityEditor;
// using UnityEngine;
// using Definitions;
// using Realisations;
// using Dependencies;
// using System;

// [CustomPropertyDrawer(typeof(IBehaviour), true)]
// public class BehaviourDrawer: PropertyDrawer 
// {
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
//     {
//         GUILayout.BeginHorizontal(); 
//         EditorGUI.indentLevel = 0;
//         GUILayout.Box(new GUIContent{text = label.text}, GUILayout.MaxHeight(15f), GUILayout.ExpandHeight(true));
//         if (GUILayout.Button("Disable", GUILayout.MaxWidth(100f), GUILayout.ExpandHeight(true)))
//         {
//             var realisation = property.serializedObject.targetObject as BehaviourRealisation;

//             realisation.EjectBehaviour(property as IBehaviour);
//             if (GUILayout.Button("Enable", GUILayout.MaxWidth(100f), GUILayout.ExpandHeight(true)))
//             {
//                 realisation.InjectBehaviour(property as IBehaviour);
//             }
//         }
        
//         GUILayout.EndHorizontal();
//     }
// }
// #endif