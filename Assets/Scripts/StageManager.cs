using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GameObject stagePrefab;
    public List<Stage> stages;
    
    int current = 0;
    public void Init(int[] starInfos)
    {
        //stages = GetComponentsInChildren<Stage>();
        for (int i=0;i<stages.Count;i++)
        {
            if (stages[i] != null)
            {

                stages[i].Init(starInfos[i]);
            }
            else
            {
                stages[i] = new Stage();
            }
            
        }
    }
    public Stage StartStage(int stage)
    {
        stages[current].SetActive(false);
        stages[stage-1].SetActive(true);
        stages[stage - 1].Clear();
        current = stage-1;
        return stages[stage-1];
        
    }

    public int GetStageStar(int stage)
    {
        return stages[stage - 1].Star;
    }

    public void AddStage(GameObject go)
    {
        go.transform.SetParent(transform);
        for(int i = 0; i < stages.Count; i++)
        {
            if(stages[i] == null)
            {
                stages[i] = go.GetComponent<Stage>();
                go.name = "Stage " + (i + 1);
                stages[i].stageNumber = i + 1;
                break;
            }
        }
    }
}
