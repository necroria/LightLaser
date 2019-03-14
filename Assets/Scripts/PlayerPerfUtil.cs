using UnityEngine;
using UnityEditor;
public enum DataSaveKey { MAXSTAGE, MAXCLEARSTAGE, STAGECOUNT, STAGE_STAR_, RECENTSTAGE, SENSITIVITY,VOLUME }
public class PlayerPerfUtil
{
    public static PlayerData Init()
    {
        PlayerData pd = new PlayerData
        {
            MaxStage = 4,
            MaxClearStage = 0,
            StageCount = 240,
            RecentStage = 1
        };
        pd.starInfos = new int[pd.StageCount];
        for(int i = 1; i <= pd.StageCount; i++)
        {
            pd.SetStarInfo(i, 0);
        }
        PlayerPerfUtil.Save(DataSaveKey.VOLUME.ToString(), 50);
        PlayerPerfUtil.Save(DataSaveKey.SENSITIVITY.ToString(), 5);
        PlayerPrefs.SetString("SaveData","Ok");

        return pd;
    }
    public static PlayerData GetPlayerData()
    {
        PlayerData pd = null;
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            pd = Init();
        }
        else
        {
            pd = new PlayerData
            {
                MaxStage = PlayerPrefs.GetInt(DataSaveKey.MAXSTAGE.ToString()),
                MaxClearStage = PlayerPrefs.GetInt(DataSaveKey.MAXCLEARSTAGE.ToString()),
                StageCount = PlayerPrefs.GetInt(DataSaveKey.STAGECOUNT.ToString()),
                RecentStage = PlayerPrefs.GetInt(DataSaveKey.RECENTSTAGE.ToString())
            };
            pd.starInfos = new int[pd.StageCount];
            for (int i = 1; i <= pd.StageCount; i++)
            {
                pd.starInfos[i-1] = PlayerPrefs.GetInt(DataSaveKey.STAGE_STAR_.ToString() + i, 0);
            }
        }

        return pd;
    }
    
    public static int[] GetSettingData()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            return new int[] { PlayerPrefs.GetInt(DataSaveKey.SENSITIVITY.ToString()), PlayerPrefs.GetInt(DataSaveKey.VOLUME.ToString()) };
        }
        else
        {
            return null;
        }
        
    }
    public static void Save(string key,int data)
    {
        PlayerPrefs.SetInt(key, data);
    }
    
}