using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIStageStart : GUIObject
{

    float offTime = 1.0f;
    public Text text;

    public void StartStage(int stageNumber)
    {
        gameObject.SetActive(true);
        text.text = "stage " + stageNumber.ToString();
        StartCoroutine(Off());
    }
    IEnumerator Off()
    {
        yield return new WaitForSeconds(offTime);
        GUIManager.Instance.StageTransition(GUIName.PLAY);        
    }
}
