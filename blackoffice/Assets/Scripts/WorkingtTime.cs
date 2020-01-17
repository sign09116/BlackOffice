using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class WorkingtTime : MonoBehaviour
{
    public int WorkTime;
    public float w_Time = 0;

    //public int WorktTime { get; private set; }






    public void T_Rest()
    {
        w_Time = 0;




    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        //w_Time = Time.time;
        //WorktTime = Mathf.FloorToInt(w_Time);
        //GetComponent<Text>().text = WorktTime.ToString();


        w_Time++;
        if (w_Time == 360)
        {
            WorkTime++;
            if (WorkTime < 10)
            {
                GetComponent<Text>().text = "0" + WorkTime.ToString();
                T_Rest();

            }
            else  if (WorkTime >= 10)
            {
                GetComponent<Text>().text = WorkTime.ToString();
                T_Rest();

            }
           
            T_Rest();

        }
        

		
	}
}
