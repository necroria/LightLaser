using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(StageManager))]
public class StageManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        StageManager stageManager = (StageManager)target;
        DrawDefaultInspector();
        if(GUILayout.Button("Add Stage"))
        {
            
            stageManager.AddStage(PrefabUtility.ConnectGameObjectToPrefab(Instantiate<GameObject>(stageManager.stagePrefab), stageManager.stagePrefab));
        }
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(stageManager);
        }
    }
}
