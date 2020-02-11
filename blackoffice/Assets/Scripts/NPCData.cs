using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "NPC資料", menuName = "DT/NPCtdata")]
public class NPCData : ScriptableObject
{
    #region  屬性
    // [Header("NPC的初始位置")]
    // public Transform NPC_O_tra;
    [Header("NPC持有的任務內容")]
    public List<QuestData> Q_data;
    [Header("任務可改變的回報對象")]
    public List<string> returnNPC_Name;
    [Header("是否處於任務中")]
    public bool isQuest;

    #endregion
}
