using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region 屬性
    [Header("道具名稱")]
    public string ItemName;
    [Header("任務接收者")]
    public string receiveMan;
    [Header("任務發佈者")]
    public string releaseMan;
    public GameManager GM;
    public bool CanUse;
    // public Dictionary<QuestData, string> dic;

    #endregion

    #region 事件
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();

    }
    #endregion

    #region 方法
    public void GetItem(string I_name, string R_name, string r_name)
    {
        ItemName = I_name;
        receiveMan = R_name;
        releaseMan = r_name;
        print(ItemName + receiveMan + releaseMan);

    }

    public void UseItem()
    {
        if (GM.CanUse)
        {
            Destroy(GameObject.Find(ItemName), 0.1f);
        }
        
    }
    #endregion

}
