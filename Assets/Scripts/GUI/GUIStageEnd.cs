using UnityEngine;


public class GUIStageEnd : GUIObject
{
    public GUIOnClickText main;
    public GUIOnClickText restart;
    public GUIOnClickText stageSelect;

    public void Init()
    {
        main.OnClickEvent += GUIManager.Instance.Main;
        restart.OnClickEvent += GUIManager.Instance.Restart;
        stageSelect.OnClickEvent += GUIManager.Instance.SelectStage;

        main.SetText("메인으로");
        restart.SetText("다시하기");
        stageSelect.SetText("스테이지 선택으로");
    }
}