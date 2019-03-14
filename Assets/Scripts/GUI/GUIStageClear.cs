using UnityEngine;


public class GUIStageClear : GUIObject
{
    public GUIOnClickText main;
    public GUIOnClickText next;
    public GUIOnClickText stageSelect;
    public GUIStarCtrl starCtrl;
    public void Init()
    {
        main.OnClickEvent += GUIManager.Instance.Main;
        next.OnClickEvent += GUIManager.Instance.Next;
        stageSelect.OnClickEvent += GUIManager.Instance.SelectStage;

        main.SetText("메인으로");
        next.SetText("다음스테이지로");
        stageSelect.SetText("스테이지 선택으로");
    }
    public void CanStartNextStage(bool value)
    {
        next.OnEvent = value;

    }
    public void SetStar(int star)
    {
        starCtrl.OnStar(star);
    }
}