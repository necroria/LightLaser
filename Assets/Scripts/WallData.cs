using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
[Serializable]
public class WallPreset
{
    public WallType type;
    public WallTag tag;
    public Sprite sprite;
}
[CreateAssetMenu(fileName = "WallData", menuName = "Wall data")]
public class WallData : ScriptableObject
{    
    public List<WallPreset> wallPreset;    
    public static float unit = 0.32f;
    public WallPreset GetWallPreSet(WallType type)
    {
        return wallPreset.Find((WallPreset x)=>x.type == type);
    }
    public Vector2[] triPath;
    public List<PhysicsMaterial2D> physicsMaterial2Ds;
}