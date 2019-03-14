using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum WallType { RBOX,NRBOX,RTRI,NRTRI,RCIRCLE,NRCIRCLE}
public enum WallTag {REFLECTION,NONREFLECTION }

public class Wall : MonoBehaviour {

    [SerializeField] SpriteRenderer sp;
    [SerializeField] WallData wallData;
    [SerializeField] WallType wallType;
    [SerializeField] float width = 1f;
    [SerializeField] float height = 1f;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    [SerializeField] float rotation = 0f;
    [SerializeField] Transform tr;
    [SerializeField] new Collider2D collider2D;
    public WallType WallType
    {
        get
        {
            return wallType;
        }

        set
        {
            wallType = value;

            tag = wallData.GetWallPreSet(wallType).tag.ToString();
            sp.sprite = wallData.GetWallPreSet(wallType).sprite;
            string typeStr = wallType.ToString();
            
            if (typeStr.Contains("BOX"))
            {
                if(collider2D.enabled)
                {
                    collider2D.enabled = false;
                }
                collider2D = GetComponent<BoxCollider2D>();
                collider2D.enabled = true;
                ((BoxCollider2D)collider2D).size = sp.size;                
            }
            else if(typeStr.Contains("TRI"))
            {
                if (collider2D.enabled)
                {
                    collider2D.enabled = false;
                }
                collider2D = GetComponent<PolygonCollider2D>();
                collider2D.enabled = true;
                ((PolygonCollider2D)collider2D).SetPath(0, wallData.triPath);
                
            }
            else if (typeStr.Contains("CIRCLE"))
            {
                if (collider2D.enabled)
                {
                    collider2D.enabled = false;
                }
                collider2D = GetComponent<CircleCollider2D>();
                collider2D.enabled = true;
                Height = 0;
                ((CircleCollider2D)collider2D).radius = Width * WallData.unit/2;
            }
            if (wallType.ToString().StartsWith("R"))
            {
                collider2D.sharedMaterial = wallData.physicsMaterial2Ds[0];
            }
            else
            {
                collider2D.sharedMaterial = wallData.physicsMaterial2Ds[1];
            }
        }
    }

    public float Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
            string typeStr = wallType.ToString();
            sp.size = Vector2.right * width * WallData.unit + Vector2.up * sp.size.y;
            if (typeStr.Contains("BOX"))
            {
                
                ((BoxCollider2D)collider2D).size = sp.size;
            }
            else if (typeStr.Contains("TRI"))
            {
                Vector2[] temp = new Vector2[wallData.triPath.Length];
                
                for(int i = 0; i < temp.Length; i++)
                {
                    temp[i] = Vector2.right * wallData.triPath[i].x * WallData.unit * width + Vector2.up * wallData.triPath[i].y * WallData.unit * height;
                }
                ((PolygonCollider2D)collider2D).SetPath(0, temp);
            }
            else if (typeStr.Contains("TRI"))
            {
                sp.size = Vector2.right * width * WallData.unit + Vector2.up * width * WallData.unit;
                ((CircleCollider2D)collider2D).radius = Width * WallData.unit / 2;
            }

        }
    }

    public float Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
            string typeStr = wallType.ToString();
            sp.size = Vector2.right * sp.size.x + Vector2.up * height * WallData.unit;
            if (typeStr.Contains("BOX"))
            {
                
                ((BoxCollider2D)collider2D).size = sp.size;
            }
            else if(typeStr.Contains("TRI"))
            {                
                Vector2[] temp = new Vector2[wallData.triPath.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = Vector2.right * wallData.triPath[i].x * WallData.unit * width + Vector2.up * wallData.triPath[i].y * WallData.unit * height;
                }
                ((PolygonCollider2D)collider2D).SetPath(0, temp);
            }else if (typeStr.Contains("CIRCLE"))
            {
                height = 0;
                sp.size = Vector2.right * width * WallData.unit + Vector2.up * width * WallData.unit;
            }
        }
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
            tr.position = Vector3.right * x * WallData.unit + Vector3.up * y * WallData.unit;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
            tr.position = Vector3.right * x * WallData.unit + Vector3.up * y * WallData.unit;
        }
    }
    public void Init()
    {
        if (sp == null)
        {
            sp = GetComponent<SpriteRenderer>();
        }
        if (tr == null)
        {
            tr = GetComponent<Transform>();
        }
    }
    void OnValidate()
    {
        if (sp == null)
        {
            sp = GetComponent<SpriteRenderer>();
        }
        if(tr == null)
        {
            tr = GetComponent<Transform>();
        }
        WallType = wallType;
        Width = width;
        Height = height;
        tr.eulerAngles = Vector3.forward * rotation;
        
        X = x;
        Y = y;
    }
}
