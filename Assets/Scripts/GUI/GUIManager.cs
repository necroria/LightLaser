using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GUIName { MAIN, STAGE_SELECT, SETTING,STAGE_START,STAGE_END,PAUSE,PLAY,STAGE_CLEAR}
public class GUIManager : MonoBehaviour {
    

    private static GUIManager instance = null;    
    public static GUIManager Instance
    {
        get
        {
            
            return instance;
        }
    }
    [SerializeField] GUIName lastGUI;
    private GUIManager() { }
    GUIName curGUI = GUIName.MAIN;
    [SerializeField] GUIMain guiMain;
    [SerializeField] GUIStageStart guiStageStart;
    [SerializeField] GUIStageSelect guiStageSelect;
    [SerializeField] GUIStageClear guiStageClear;
    [SerializeField] GUIStageEnd guiStageEnd;
    [SerializeField] GUISetting guiSetting;
    [SerializeField] GameObject guiButtonBar;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Init()
    {
        guiMain.Init();
        guiStageSelect.Init();
        guiSetting.Init();
        guiStageEnd.Init();
        guiStageClear.Init();
        GUIOnOff(GUIName.MAIN, true);
        guiButtonBar.SetActive(false);
    }

    public void StartStage(int stageNumber)
    {
        guiStageStart.StartStage(stageNumber);
    }

    public void StageTransition(GUIName name) 
    {
        GUIOnOff(curGUI, false);
        GUIOnOff(name, true);
        lastGUI = curGUI;
        curGUI = name;
        
    }

    public void StageTransition(int name)
    {
        StageTransition((GUIName)name);        
    }
    void GUIOnOff(GUIName name,bool value)
    {
        switch (name)
        {
            case GUIName.MAIN:
                guiMain.SetActive(value);
                
                break;
            case GUIName.STAGE_SELECT:
                guiStageSelect.SetActive(value);
                guiButtonBar.SetActive(value);
                break;
            case GUIName.SETTING:
                guiSetting.SetActive(value);
                guiButtonBar.SetActive(value);
                break;
            case GUIName.STAGE_START:
                guiStageStart.SetActive(value);
                break;
            case GUIName.STAGE_END:
                guiStageEnd.SetActive(value);
                break;
            case GUIName.PAUSE:
                break;
            case GUIName.PLAY:
                break;
            case GUIName.STAGE_CLEAR:
                guiStageClear.SetActive(value);
                guiStageClear.CanStartNextStage(GameManager.Instance.CanNextStage);
                
                break;
        }
    }

    public void RecentStageStart()
    {
        GameManager.Instance.RecentStageStart();
    }
    public void SelectStage()
    {
        StageTransition(GUIName.STAGE_SELECT);
    }
    public void Setting()
    {
        StageTransition(GUIName.SETTING);
    }
    public void Main()
    {
        StageTransition(GUIName.MAIN);
    }
    public void Restart()
    {
        GameManager.Instance.RecentStageStart();
    }
    public void Next()
    {
        GameManager.Instance.NextStage();
    }
    public void BackGUI()
    {
        StageTransition(lastGUI);
    }
    public void SetStar(int stage,int star)
    {
        guiStageClear.SetStar(star);
        guiStageSelect.SetStar(stage, star);
    }
    public void NewClearStage(int stage)
    {
        guiStageSelect.NewClearStage(stage);
    }
}
