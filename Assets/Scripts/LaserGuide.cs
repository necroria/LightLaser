using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//장전 형식으로
public class LaserGuide : MonoBehaviour
{
    public float power;
    bool isDraw = false;
    //LineRenderer line;
    TrailRenderer trail;
    Rigidbody2D rb;
    Transform tr;
    Collider2D coll2D;
    //int currentPosition = 0;
    public int laserCount;
    public Vector2 velocity;
    public Vector3 direction;
    public GameObject particle;
    int hitCount = 0;
    // Use this for initialization
    void Start()
    {
        //line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        trail = GetComponent<TrailRenderer>();
        coll2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame  
    void FixedUpdate()
    {
        if (isDraw)
        {
            //line.SetPosition(line.positionCount-1, tr.position);
            //direction = tr.position + Vector3.right * rb.velocity.x + Vector3.up * rb.velocity.y;
            tr.rotation= Quaternion.LookRotation(Vector3.forward, rb.velocity);
            
        }

    }
    public void Fire( Vector3 direct)
    {
        //gameObject.SetActive(true);
        
        //line.positionCount = 2;
        
        rb.AddForce(direct * power);
        //line.SetPosition(0, tr.position);
        laserCount = 0;
        trail.time = 999;
        trail.emitting = true;
        isDraw = true;
        particle.SetActive(true);
    }
    public void Load(Transform laser)
    {
        tr.position = laser.position;
        tr.SetParent(laser);
        particle.SetActive(false);
        coll2D.enabled = true;
        hitCount = 0;
    }
    public void Clear()
    {
        tr.localPosition = Vector3.zero;
        rb.velocity = Vector2.zero ;
        laserCount = 0;
        trail.time = 0;
        particle.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gObj = collision.gameObject;
        if (gObj.CompareTag("REFLECTION"))
        {
            //line.positionCount++;
            GameManager.Instance.hitCount++;
            hitCount++;
        }
        else if (gObj.CompareTag("LASER"))
        {
            if (hitCount != 0)
            {
                Stop();
                GameManager.Instance.ReadyFire= true;
            }            
        }
        else if (gObj.CompareTag("NONREFLECTION"))
        {
            Stop();
            GameManager.Instance.ReadyFire = true;
        }
        else if (gObj.CompareTag("TARGET"))
        {
            //TargetHit();
            GuideStop();
            GameManager.Instance.ReadyFire = true;
        }
    }
    public void Stop()
    {
        GuideStop();
        GameManager.Instance.PlayEnd();
    }
    public void TargetHit()
    {
        //GuideStop();

        //클리어 조건 확인 후 클리어면 넥스트 스테이지, 클리어시 스타 조건 확인 후 스타 확정
        GameManager.Instance.NextStage();

        //line.positionCount = 0;
        //gameObject.SetActive(false);
    }
    void GuideStop()
    {
        rb.velocity = Vector2.zero;
        isDraw = false;
        trail.emitting = false ;
        coll2D.enabled = false;
        particle.SetActive(false);
        tr.SetParent(GameManager.Instance.guideParent);
    }
}
