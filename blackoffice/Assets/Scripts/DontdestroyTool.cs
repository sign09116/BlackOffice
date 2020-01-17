using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontdestroyTool : MonoBehaviour
{
    #region 屬性
    [Header("是否切換場景時不被刪除")]
    public bool DontdestroyOnLoad = true;
    [Header("是否回到這場景時不產生新物件")]
    public bool DontCreateNewWhenBacktoThisScene = true;
    [Header("不刪除物件工具管理器")]
    public static DontdestroyTool Instance = null;
    #endregion

    #region 方法
    #endregion

    #region 事件
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        if (this.DontdestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

}
