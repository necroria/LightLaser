using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Stage))]
public class StageEditor : Editor {
    float[] widths = { 11,11,1,1};
    float[] heights = { 1,1,20,20};
    float[] x = { 0, 0,5, -5 };
    float[] y = { 10.5f, -10.5f,0,0};


    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        Stage stage = (Stage)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Add Wall"))
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/BasicWall.prefab");
            GameObject go = PrefabUtility.ConnectGameObjectToPrefab(Instantiate<GameObject>(prefab), prefab);
            stage.AddWall(go);
        }
        if (GUILayout.Button("Add Target"))
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Target.prefab");
            GameObject go = PrefabUtility.ConnectGameObjectToPrefab(Instantiate<GameObject>(prefab), prefab);
            stage.AddTarget(go);
        }
        if (GUILayout.Button("Add Outer Wall"))
        {
            for(int i = 0; i < 4; i++)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/BasicWall.prefab");
                GameObject go = PrefabUtility.ConnectGameObjectToPrefab(Instantiate<GameObject>(prefab), prefab);
                Wall wall = go.GetComponent<Wall>();
                wall.Init();
                wall.WallType = WallType.RBOX;
                wall.Width = widths[i];
                wall.Height = heights[i];
                wall.X = x[i];
                wall.Y = y[i];
                stage.AddWall(go);
            }            
        }
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(stage);
        }
        
    }
}
