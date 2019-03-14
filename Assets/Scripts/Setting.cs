using UnityEngine;
using System.Collections;


public class Setting : MonoBehaviour
{
    [SerializeField] private int sensitivity;
    private int volume;

    public int Sensitivity
    {
        get
        {
            return sensitivity;
        }
        set
        {
            sensitivity = value;
            PlayerPerfUtil.Save(DataSaveKey.SENSITIVITY.ToString(), value);
        }
    }

    public int Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
            PlayerPerfUtil.Save(DataSaveKey.VOLUME.ToString(), value);
        }
    }

    public void Init()
    {
        int[] data = PlayerPerfUtil.GetSettingData();
        if(data == null)
        {
            Sensitivity = 5;
            Volume = 50;
        }
        else
        {
            sensitivity = data[0];
            volume = data[1];
        }

        
    }

}
