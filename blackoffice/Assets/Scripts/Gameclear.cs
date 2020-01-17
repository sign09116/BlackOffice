using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour
{
    #region 屬性
    public GameObject GameClearInterFace;


    #endregion


    #region 方法
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    #endregion


    #region 事件
    private void Awake()
    {
        GameClearInterFace.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameClearInterFace.SetActive(true);
        }
    }
    #endregion

}
