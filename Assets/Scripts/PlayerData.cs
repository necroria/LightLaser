using UnityEngine;
using System.Text;
using System;
[Serializable]
public class PlayerData
{
    private int recentStage = 1;
    private int maxStage;
    private int maxClearStage;
    private int stageCount;
    
    public int[] starInfos;

    public int MaxClearStage
    {
        get
        {
            return maxClearStage;
        }

        set
        {
            maxClearStage = value;
            PlayerPerfUtil.Save(DataSaveKey.MAXCLEARSTAGE.ToString(),value);
        }
    }
    public int MaxStage
    {
        get
        {
            return maxStage;
        }

        set
        {
            maxStage = value;
            PlayerPerfUtil.Save(DataSaveKey.MAXSTAGE.ToString(), value);
        }
    }
    public int StageCount
    {
        get
        {
            return stageCount;
        }

        set
        {
            stageCount = value;
            PlayerPerfUtil.Save(DataSaveKey.STAGECOUNT.ToString(), value);
        }
    }

    public int RecentStage
    {
        get
        {
            return recentStage;
        }

        set
        {
            recentStage = value;
            PlayerPerfUtil.Save(DataSaveKey.RECENTSTAGE.ToString(), value);
        }
    }

    public static PlayerData GetPlayerData()
    {
        //PlayerData pd =Resources.Load<PlayerData>("Data/PlayerData.json");
        PlayerData pd = PlayerPerfUtil.GetPlayerData() ;
        
        return pd;
    }
    public void SetStarInfo(int stage,int data)
    {
        starInfos[stage - 1] = data;
        PlayerPerfUtil.Save(DataSaveKey.STAGE_STAR_.ToString()+stage, data);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Max Stage " + MaxStage);
        sb.AppendLine("Max Clear Stage " + maxClearStage);
        sb.AppendLine("stage count " + stageCount);
        sb.AppendLine("recent stage " + recentStage);
        sb.AppendLine("star info");
        for(int i = 0; i < stageCount / 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                sb.Append(starInfos[i * 10 + j]+" ");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}