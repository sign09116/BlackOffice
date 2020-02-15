using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConferenceRoom : MonoBehaviour
{
    #region 屬性
    public NPCData data;

    #endregion

    #region 事件
    private void Start()
    {
        for (int i = 0; i < data.filePos.Length; i++)
        {
            Vector3 pos = data.filePos[i].transform.position;
            print(pos);
        }
    }
    #endregion

    #region 方法

    #endregion

}