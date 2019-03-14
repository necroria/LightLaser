using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public Stage stage;
    [SerializeField]Transform tr;
    int targetNumber;
    public void Init(Stage stage,int targetNumber)
    {
        this.stage = stage;
        this.targetNumber = targetNumber;
        //tr = GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LASERGUIDE"))
        {
            stage.HitTarget(targetNumber);
        }
    }
    public Vector2 position;

    public Vector2 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
            tr.position = Vector3.right * WallData.unit * position.x + Vector3.up * WallData.unit * position.y;
        }
    }
    private void OnValidate()
    {
        if(tr == null)
        {
            tr = GetComponent<Transform>();
        }
        Position = position;
    }
}
