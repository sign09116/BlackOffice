using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class WorkingtTime : MonoBehaviour
{
    public int WorkTime;
    public int HR=17;
    public Text hrtext;
    public float w_Time = 0;
    /// <summary>
    /// 總遊戲時間
    /// </summary>
    int m_totaltime;
    /// <summary>
    /// 儲存總遊戲時間欄位
    /// </summary>
public string totaltTime="totaltTime";
    //public int WorktTime { get; private set; }






    public void T_Rest()
    {
        w_Time = 0;




    }

    // Use this for initialization
    void Start()
    {
hrtext=GameObject.Find("時刻").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        //w_Time = Time.time;
        //WorktTime = Mathf.FloorToInt(w_Time);
        //GetComponent<Text>().text = WorktTime.ToString();


        w_Time++;
        if (w_Time == 360)
        {
            m_totaltime ++;
            WorkTime++;
            if (WorkTime < 10)
            {
                GetComponent<Text>().text = "0" + WorkTime.ToString();
                T_Rest();

            }
            else if (WorkTime >= 10)
            {
                GetComponent<Text>().text = WorkTime.ToString();
                T_Rest();

            }
            if (WorkTime > 60)
            {
                WorkTime = 0;
                HR++;
                hrtext.text=HR.ToString();
            }
        PlayerPrefs.SetInt(totaltTime,m_totaltime); 
            T_Rest();

        }



    }
}
