using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : GUIObject
{

    public GUIOnClickText recentStart;
    public GUIOnClickText stageSelect;
    public GUIOnClickText setting;

    public void Init()
    {
        recentStart.OnClickEvent += GUIManager.Instance.RecentStageStart;
        stageSelect.OnClickEvent += GUIManager.Instance.SelectStage;
        setting.OnClickEvent += GUIManager.Instance.Setting;

        recentStart.SetText("최근 스테이지");
        stageSelect.SetText("스테이지 선택");
        setting.SetText("설정");
    }

    
}
