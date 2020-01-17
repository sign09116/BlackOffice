using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownStairs : MonoBehaviour
{
    #region 屬性
    public string NextSceneName;
    public GameObject _player;
    public Animator Blackaim;
    #endregion


    #region 方法
    public void PlayerisChangeScene()
    {
        SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
        WaitForFixedUpdate wait = new WaitForFixedUpdate();
        GameObject.FindGameObjectWithTag("BlackScene").transform.SetAsFirstSibling();
    }
    #endregion
    #region 事件

    private void Awake()
    {
        Blackaim = GameObject.FindGameObjectWithTag("BlackScene").GetComponent<Animator>();
        // _player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("BlackScene").transform.SetAsLastSibling();
            Blackaim.SetTrigger("黑畫面");
            Debug.Log("玩家進入");
            _player.GetComponent<CapsuleCollider2D>().enabled = false;
            Invoke("PlayerisChangeScene", 1.5f);


        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {


        Debug.Log("玩家離開");

        _player.GetComponent<CapsuleCollider2D>().enabled = true;


    }
    #endregion

}
