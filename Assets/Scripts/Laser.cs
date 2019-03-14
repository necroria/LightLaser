using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour

{
    Transform tr;
    GameObject gObj;
    public Transform firePos;
    public Vector3 clickPoint;
    
    LaserGuide guide;
    int countGuide=0;


    private void OnMouseUp()
    {
        if (!GameManager.Instance.ReadyFire)
        {
            return;
        }
        FireLaser();
        GameManager.Instance.ReadyFire = false ;
    }
    private void OnMouseDrag()
    {
        if (!GameManager.Instance.ReadyFire)
        {
            return;
        }
        Vector3 curPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float degree = DegreeOfRotation(curPoint, clickPoint);
        tr.Rotate(Vector3.forward * degree*90);
        clickPoint = curPoint;

    }
    
    private void OnMouseDown()
    {
        if (!GameManager.Instance.ReadyFire)
        {
            return;
        }
        if (GameManager.Instance.IsPlaying)
        {
            clickPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
            Load();
        }
    }

    float DegreeOfRotation(Vector3 curPoint, Vector3 clickPoint)
    {
        return (-(curPoint.x - clickPoint.x) + (curPoint.y - clickPoint.y)) * GameManager.Instance.setting.Sensitivity;
    }
    public void Init()
    {
        tr = GetComponent<Transform>();
        gObj = gameObject;
    }
    public void NextStage()
    {
        countGuide = 0;
    }
    void FireLaser()
    {
        guide.Fire(tr.up);

        countGuide++;
    }
    public void SetPosition(Vector2 position)
    {
        tr.position = position;
    }
    public void SetRotation(float rotation)
    {
        tr.eulerAngles = Vector3.forward * rotation;
    }
    public void SetActive(bool value)
    {
        gObj.SetActive(value);
    }
    public void Load()
    {
        //guides[countGuide].Load(firePos);
        LaserManager lm = GameManager.Instance.laserManager;
        guide = lm.GetGuide();
        guide.Load(firePos);
    }
    public void Clear()
    {
        GameManager.Instance.ReadyFire = true;
        countGuide = 0;
        tr.rotation = Quaternion.identity;
    }
    
}
