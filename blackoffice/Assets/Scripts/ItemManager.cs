using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    #region 屬性
    [Header("道具名稱")]
    public string ItemName;
    [Header("任務接收者")]
    public string _questnqame;
    [Header("任務名稱")]
    public string releaseMan;
    public GameManager GM;
    public Button button;
    public bool CanUse;
    // public Dictionary<QuestData, string> dic;

    #endregion

    #region 事件
    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseItem);
    }
    #endregion

    #region 方法
    public void GetItem(string I_name, string R_name, string r_name)
    {
        ItemName = I_name;
        _questnqame = R_name;
        releaseMan = r_name;
        print(ItemName + _questnqame + releaseMan);

    }
    public void saveIteminfo()
    {

    }

    public void UseItem()
    {
        if (GM.CanUse)
        {
            if (gameObject.name != "任務道具3(Clone)")
            {
                if (gameObject.name == "任務道具(Clone)")
                {
                    GameObject FT = GameObject.Find("將文件交給" + releaseMan);
                    Destroy(FT, 0.1f);
                }

                Destroy(GameObject.Find(ItemName), 0.1f);
            }
            if (gameObject.name == "任務道具3(Clone)" && gameObject.GetComponent<Animator>().GetBool("裝滿"))
            {
                GameObject MT = GameObject.Find("請幫我倒杯咖啡");
                Destroy(MT, 0.1f);
                Destroy(GameObject.Find("任務道具3(Clone)"), 0.1f);
            }
            GM.QuestClear(_questnqame, releaseMan);
        }
    }
    public void ChooseItem()
    {
        print("以選擇道具" + gameObject.name);
    }

    #endregion

}
