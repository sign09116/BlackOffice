
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class QuestCheckManager : MonoBehaviour
{
    #region 屬性
    public string reurnNPC;
    public GameManager C_GM;
    #endregion
    #region 事件
    private void Start()
    {

        C_GM = GameObject.FindObjectOfType<GameManager>();
        this.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D stay)
    {
        if (stay.tag == "Player")
        {
            string name = C_GM.ReCheckMan[0];
            // reurnNPC = name;
        }
    }



    #endregion
    #region 方法


    /// <summary>
    /// 檢查任務內容方法
    /// </summary>
    public void Check()
    {
        print("檢察任務");
    }
    #endregion

}
