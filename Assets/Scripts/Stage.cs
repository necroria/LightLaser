using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage : MonoBehaviour {

    [SerializeField] int star;
    public int stageNumber;
    public int Star
    {
        set { star = value; }
        get { return star; }
    }
    HashSet<int> hitTargets = new HashSet<int>();
    public List<Target> targets;
    int HitTargetCount
    {
        get { return hitTargets.Count; }
    }
    public int condition01 = 1;
    public int condition02 = 2;
    Transform walls;
    Transform targetsTr;
    new GameObject gameObject;
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
    public void Init(int star)
    {
        this.star = star;
        gameObject = base.gameObject;

        for (int i = targets.Count - 1; i >= 0; i--)
        {

            if (targets[i] == null)
            {

                targets.RemoveAt(i);
            }
        }
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].Init(this,i);
        }
        
        SetActive(false);
    }
    //사용하는 레이저 종류 레이저 갯수 시작 위치를 알 수 있어야 함
    public LaserSet[] laserSets;
    [Serializable]
    public struct LaserSet
    {
        public int laserNum;
        public Vector2 position;
        public float rotation;
    }
    public void Clear()
    {
        hitTargets.Clear();        
    }
    public void HitTarget(int targetNumber)
    {
        if (!hitTargets.Contains(targetNumber))
        {
            hitTargets.Add(targetNumber);
            if (HitTargetCount == targets.Count)
            {
                GameManager.Instance.StageClear();
            }
        }
    }

    public void AddWall(GameObject go)
    {
        go.transform.SetParent(walls);
        //Instantiate<GameObject>(go,walls);
    }
    public void AddTarget(GameObject go)
    {
        go.transform.SetParent(targetsTr);
        for (int i = targets.Count - 1; i >= 0; i--)
        {

            if (targets[i] == null)
            {

                targets.RemoveAt(i);
            }
        }
        targets.Add(go.GetComponent<Target>());
        //Instantiate<GameObject>(go,walls);
    }
    private void OnValidate()
    {
        if(walls == null)
        {
            walls = transform.Find("Wall");
        }
        if (targetsTr == null)
        {
            targetsTr = transform.Find("Targets");
        }

    }
}
