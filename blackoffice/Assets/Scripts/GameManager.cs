using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DT;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region 屬性
    public GameObject Player;
    public string PlayerName = "PlayerName";
    public GameObject[] NPC;
    public GameObject[] ActionButton;
    public bool CanMove;
    private PointerEventData EventData;
    public float CanMovetime;
    public GameObject saydialog;
    public Transform playerstandpoint;
    public Transform _Npc;
    // public BoxCollider2D standpoint;
    // public BoxCollider2D Npctouchpoint;
    public Animator backgroundAim;
    [Header("遊戲開始按鈕物件")]
    public GameObject backgroundObj;
    /// <summary>
    /// 遮擋移動方向鍵遮罩
    /// </summary>
    public GameObject maskObj;
    [Header("任務道具按鈕")]
    public Button[] RewardButton;
    [Header("任務到具替換圖片")]
    public Sprite[] changeSprite;
    [Header("替換道具文字")]
    public string[] changeText;
    [Header("玩家名稱輸入欄位")]
    public Text _inputname;
    /// <summary>
    /// 玩家持有任務清單
    /// </summary>
    public List<QuestData> HaveQuest;
    [Header("回報對象清單")]
    public List<string> ReCheckMan;
    [Header("代辦事項物件")]
    public GameObject Agendumobj;
    public GameObject MissionText;
    #endregion



    #region 方法
    // void playerischangscene()
    // {

    //     Player.GetComponent<CapsuleCollider2D>().enabled = true;
    // }


    #endregion




    #region 事件
    private void Awake()
    {
        if (Application.loadedLevelName == "sence1")
        {

            saydialog = GameObject.Find("對話框");
            maskObj = GameObject.Find("controlMask");
            maskObj.GetComponent<Image>().raycastTarget = false;
            saydialog.SetActive(false);
        }
    }
    private void Start()
    {
        Agendumobj = GameObject.Find("任務介面");
        MissionText = Resources.Load("任務內容") as GameObject;
        if (Application.loadedLevelName == "Menu")
        {
            Invoke("showBackground", 15f);

        }

    }
    private void Update()
    {

        // if (!Player.GetComponent<CapsuleCollider2D>().enabled)
        // {
        //     Invoke("playerischangscene", 5f);
        // }
        // if (Player.GetComponent<PlayerMovecontrol>().inDeadZoom)
        // {
        //     CanMovetime++;
        //     if (CanMovetime >= 300)
        //     {
        //         Player.GetComponent<PlayerMovecontrol>().inDeadZoom = false;
        //     }
        // }


    }


    #endregion
    void showBackground()
    {
        backgroundObj.SetActive(true);
    }
    public void GetPlayerName()
    {
        PlayerPrefs.SetString(PlayerName, _inputname.text);
        Debug.Log(("玩家名稱") + PlayerName);
    }

}
