using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour {
    public Laser[] lasers;
    public LaserGuide[] laserGuide;
    int curGuide = 0;
	public Laser GetLaser(int num)
    {
        return lasers[num];
    }
    public void LaserSetting(Stage.LaserSet laserSet)
    {
        int i = laserSet.laserNum;
        
        lasers[i].SetPosition(laserSet.position);
        lasers[i].SetRotation(laserSet.rotation);
        lasers[i].Clear();
        lasers[i].SetActive(true);
        curGuide = 0;
        
    }
    void Start()
    {
        for(int i=0;i<lasers.Length; i++)
        {
            lasers[i].Init();
        }
        laserGuide = GameObject.Find("LaserGuides").GetComponentsInChildren<LaserGuide>();
    }
    public LaserGuide GetGuide()
    {
        
        if (curGuide>laserGuide.Length)
        {
            curGuide = 0;
        }
        
        return laserGuide[curGuide++];
    }
    public void ClearLaser()
    {
        for(int i = 0; i < lasers.Length; i++)
        {
            lasers[i].Clear();
            lasers[i].SetActive(false);
        }
        for (int j = 0; j < laserGuide.Length; j++)
        {
            laserGuide[j].Clear();
        }
    }
}
