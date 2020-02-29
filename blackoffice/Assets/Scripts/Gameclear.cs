using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameclear : MonoBehaviour
{
    #region 屬性
    public GameObject GameClearInterFace;
    public GameManager GM;
    public WorkingtTime workingtTime;
    public Text total_timetext,totalpaytext;
    public int C_totaltime;
    public int pay;
    public GameObject dontdestroy;
    public Button back;
    /// <summary>
    /// 儲存總遊戲時間欄位
    /// </summary>
public string totaltTime="totaltTime";

    #endregion


    #region 方法
    public void OnMenuButtonClick()
    { PlayerPrefs.DeleteKey(totaltTime);
    Destroy(dontdestroy,0.01f);
    SceneManager.LoadScene("Menu");
    }
        
       

    #endregion


    #region 事件
    private void Awake()
    {
        GameClearInterFace.SetActive(false);
        GM = GameObject.FindObjectOfType<GameManager>();
        dontdestroy=GameObject.Find("DontDestroyObj");
        
   

    }
     private void Start()
    {
        
    C_totaltime=PlayerPrefs.GetInt(totaltTime);
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GM.HaveQuest.Count==0)
            {
                showClearInterFace();
                back.onClick.AddListener(OnMenuButtonClick);
            }
            else
            {
                return;
            }

        }
    }
   

    private void showClearInterFace()
    {GameClearInterFace.SetActive(true);
    back=GameObject.Find("MenuButton").GetComponent<Button>();
     total_timetext=GameObject.FindGameObjectWithTag("加班時數").GetComponent<Text>();
    totalpaytext=GameObject.FindGameObjectWithTag("欠薪").GetComponent<Text>();
        total_timetext.text=C_totaltime.ToString("0.0")+"分鐘";//總加班時數取到小數點第一位
        totalpaytext.text=(C_totaltime*10)+"元";
    }
    #endregion

}
