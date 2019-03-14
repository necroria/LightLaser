using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIStarCtrl : MonoBehaviour {

    [SerializeField]GameObject[] goldStars;
    
    public void OnStar(int number)
    {
        for(int i = 0; i < 3; i++)
        {
            goldStars[i].SetActive(number > i);
        }
    }
}
