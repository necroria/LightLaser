using UnityEngine;
using UnityEngine.UI;

public class GUIStageSelect : GUIObject
{
    [SerializeField] Transform tabTr;
    [SerializeField] Transform groupTr;

    Button[] tabButton;
    Text[] tabText;
    Button[] groupButton;
    Text[] groupText;
    GUIStarCtrl[] groupStar;

    int curGroup=0;

    public void Init()
    {
        tabButton = tabTr.GetComponentsInChildren<Button>();
        tabText = tabTr.GetComponentsInChildren<Text>();
        groupButton = groupTr.GetComponentsInChildren<Button>();
        groupText= groupTr.GetComponentsInChildren<Text>();
        groupStar = groupTr.GetComponentsInChildren<GUIStarCtrl>();
        for (int i = 0; i < tabButton.Length; i++)
        {
            int index = i;
            tabText[i].text = (i * 40 + 1) + " ~ " + ((i + 1) * 40);
            
            tabButton[i].onClick.AddListener(() => GroupChange(index));
        }
        GroupChange(curGroup);
        gameObject.SetActive(false);
    }

    void GroupChange(int index)
    {
        curGroup = index;
        for (int i = 1; i <= groupButton.Length; i++)
        {           
            SetButton( i,GameManager.Instance.GetStar(i));
        }
    }
    void StageSelect(int stage)
    {
        GameManager.Instance.StartStage(stage);
    }
    void SetButton(int stage,int starCount)
    {
        int index = stage - 1;
        groupButton[index].onClick.RemoveAllListeners();
        groupButton[index].interactable = GameManager.Instance.MaxStage>= stage + 40 * curGroup && GameManager.Instance.MaxClearStage+1>=stage + 40 * curGroup;
        groupStar[stage - 1].OnStar(starCount);
        groupText[index].text = (stage + 40 * curGroup).ToString();
        groupButton[index].onClick.AddListener(() => StageSelect(stage + 40 * curGroup));
    }
    public void SetStar(int stage, int starCount)
    {
        if ((stage - 1) / 40 == curGroup)
        {
            groupStar[stage - 1].OnStar(starCount);
        }       
    }
    public void NewClearStage(int stage)
    {
        if ((stage - 1) / 40 == curGroup)
        {
            if (stage % 40 != 0)
            {
                groupButton[stage].interactable = GameManager.Instance.MaxStage > stage + 40 * curGroup&&true;
            }            
        }
    }
}