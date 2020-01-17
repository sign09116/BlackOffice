using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="任務資料",menuName="DT/Questdata")]
public class QuestData : ScriptableObject
{
    [Header("命令者名稱")]
    public string OrderMaster;
    [Header("接收者名稱")]
    public string checkMan;
    [Header("任務訊息")]
    public string[] Q_Massage;
    [Header("給予道具")]
    public GameObject RewardItem;

}
