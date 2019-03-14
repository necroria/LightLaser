using UnityEngine;

public enum PlayState { MAIN,PLAY,END,CLEAR}

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    //[SerializeField] private int maxClearStage = 0;
    public int MaxClearStage
    {
        get { return playerData.MaxClearStage; }
    }
    public bool ReadyFire
    {
        get
        {
            if (playState != PlayState.PLAY)
            {
                return false;
            }
            return onfire;
        }
        set
        {
            onfire = value;            
        }
    }
    int currentStage = 1;
    public int maxStage;
    public StageManager stageManager;
    public LaserManager laserManager;
    public Transform guideParent;
    public Setting setting;
    public int MaxStage
    {
        get { return playerData.MaxStage; }
    }
    public int hitCount;
    public Stage curStage;
    public PlayState playState = PlayState.MAIN;
    PlayerData playerData;
    public bool onfire = true;
	// Use this for initialization
	void Start () {
        
        instance = this;
        playerData = PlayerData.GetPlayerData();
        playerData.MaxStage = maxStage;
        Debug.Log(playerData);
        //maxClearStage = playerData.MaxClearStage;
        //maxStage = playerData.MaxStage;
        stageManager.Init(playerData.starInfos);
        setting.Init();
        GUIManager.Instance.Init();
        //stageManager.StartStage(currentStage);
	}
    public void NextStage()
    {
        StartStage(++currentStage);        
    }
    public void StartStage(int stageNumber)
    {
        if (stageNumber > MaxStage)
        {
            PlayEnd();            
            return;
        }
        hitCount = 0;
        ReadyFire = true;
        playState = PlayState.PLAY;
        curStage = stageManager.StartStage(stageNumber);
        
        GUIManager.Instance.StageTransition(GUIName.STAGE_START);
        GUIManager.Instance.StartStage(stageNumber);
        laserManager.ClearLaser();
        for (int i = 0; i < curStage.laserSets.Length; i++)
        {
            laserManager.LaserSetting(curStage.laserSets[i]);
        }
        currentStage = stageNumber;
        RecentStage = stageNumber;
    }
    public void RecentStageStart()
    {
        StartStage(RecentStage);
    }
    public int GetStar(int stage)
    {
        return stageManager.GetStageStar(stage);
    }
    public void PlayEnd()
    {
        GUIManager.Instance.StageTransition(GUIName.STAGE_END);
        playState = PlayState.END;
    }
    public bool IsPlaying
    {
        get { return playState == PlayState.PLAY; }
    }
    public void StageClear()
    {
        
        playState = PlayState.CLEAR;
        if(curStage.Star == 0)
        {
            playerData.MaxClearStage = RecentStage;
            GUIManager.Instance.NewClearStage(RecentStage);
        }
        //check 조건
        int star = 1;
        if (hitCount < curStage.condition01)
        {
            star++;
        }
        if (hitCount < curStage.condition02)
        {
            star++;
        }
        if (star>playerData.starInfos[RecentStage - 1])
        {
            playerData.SetStarInfo(RecentStage, star);
            GUIManager.Instance.SetStar(RecentStage, star);
            curStage.Star = star;
        }
        else
        {
            GUIManager.Instance.SetStar(RecentStage, playerData.starInfos[RecentStage - 1]);
        }
        GUIManager.Instance.StageTransition(GUIName.STAGE_CLEAR);
    }
    public bool CanNextStage
    {
        get { return MaxStage > RecentStage; }
    }

    public int RecentStage
    {
        get
        {
            return playerData.RecentStage;
        }

        set
        {
            playerData.RecentStage = value;
        }
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 10, 10), "reset"))
        {
            PlayerPerfUtil.Init();            
        }
    }
}
