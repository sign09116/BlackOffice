
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

    }

    private void OnTriggerStay2D(Collider2D stay)
    {

    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.GetComponent<Collider2D>().tag == "Player")
        {
            print("可繳回道具");
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
