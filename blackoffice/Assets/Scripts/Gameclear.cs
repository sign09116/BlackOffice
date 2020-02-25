using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour
{
    #region 屬性
    public GameObject GameClearInterFace;
    public GameManager GM;
    public WorkingtTime workingtTime;
    public int pay;


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
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GM.HaveQuest == null)
            {
                GameClearInterFace.SetActive(true);
            }
            else
            {
                return;
            }

        }
    }
    private void Start()
    {
        workingtTime = GameObject.FindObjectOfType<WorkingtTime>();

    }
    #endregion

}
