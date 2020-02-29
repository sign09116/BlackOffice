using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerMovecontrol : MonoBehaviour

{
    #region 屬性

    public float MoveSpeed;
    public GameManager GM;
    public NpcBehavior GetNPCBehavior;
    public GameObject[] MoveButton;
    public Rigidbody2D PlayerRd;
    public Transform PlayerTm;
    public SpriteRenderer PlayerSP;
    public Sprite[] idel;
    public bool MoveUP = false;
    public bool MoveDown = false;
    public bool MoveRight = false;
    public bool MoveLeft = false;
    public int ButtonIndex;
    public Collider2D DeadZoom;
    public Transform standingPoint;
    public bool inDeadZoom;
    public Animator PlayerAni;
    public bool canMove;

    #endregion




    #region 方法
    public void StopMove()
    {

        StopAllCoroutines();
        PlayerRd.freezeRotation.CompareTo(inDeadZoom);
    }
    public void PlayerChangeScene()
    {
        // switch (Application.loadedLevelName)
        // {
        //     case "sence2":
        //     PlayerTm.GetComponent<Collider2D>().enabled = false;
        //     

        //         break;
        // }
        // if (Application.loadedLevelName != "sence1")
        // {
        //     PlayerTm.GetComponent<CapsuleCollider2D>().enabled = false;


        // }







    }

    #endregion

    #region 事件
    private bool _pointerDown;
    private Coroutine _moveCoroutine;



    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
        GetNPCBehavior = GameObject.FindObjectOfType<NpcBehavior>();
        PlayerAni = GetComponent<Animator>();
        PlayerSP = GetComponent<SpriteRenderer>();

    }
    public void OnMoveUpDown()
    {
        canMove = true;
        MoveUP = true;
        PlayerAni.SetBool("向上", true);
        // _moveCoroutine = StartCoroutine(Move(Vector2.up));
    }

    public void OnMoveUpUp()
    {
        MoveUP = false;
        PlayerAni.SetBool("向上", false);
        // StopCoroutine(_moveCoroutine);
    }


    public void OnMoveDownDown()
    {
        canMove = true;
        MoveDown = true;
        PlayerAni.SetBool("向下", true);

        // _moveCoroutine = StartCoroutine(Move(Vector2.down));
    }

    public void OnMovedownUp()
    {
        MoveDown = false;
        PlayerAni.SetBool("向下", false);
        PlayerSP.sprite = idel[3];
        // StopCoroutine(_moveCoroutine);
    }


    public void OnMoverightDown()
    {
        canMove = true;
        MoveRight = true;
        PlayerAni.SetBool("向右", true);


        // _moveCoroutine = StartCoroutine(Move(Vector2.right));

    }

    public void OnMoverightUp()
    {
        MoveRight = false;
        PlayerAni.SetBool("向右", false);
        PlayerSP.sprite = idel[2];
        // StopCoroutine(_moveCoroutine);

    }



    public void OnMoveleftDown()
    {
        canMove = true;
        MoveLeft = true;
        PlayerAni.SetBool("向左", true);

        // _moveCoroutine = StartCoroutine(Move(Vector2.left));
    }

    public void OnMoveleftUp()
    {
        MoveLeft = false;
        PlayerAni.SetBool("向左", false);
        PlayerSP.sprite = idel[1];
        // StopCoroutine(_moveCoroutine);
    }


    // private IEnumerator Move(Vector2 direction)
    // {
    //     while (true)
    //     {
    //         PlayerRd.MovePosition(PlayerRd.position + direction * Time.fixedDeltaTime * MoveSpeed);
    //         yield return null;
    //     }
    // }


    //public void OnTriggerStay(Collider2D other)
    //{


    //}

    public void FaceNPC(Transform npc)
    {
        Vector2 dir = (npc.position - transform.position);
        if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            if (npc.position.x >= transform.position.x)
            {
                // PlayerRd.MoveRotation(0);
                PlayerAni.SetTrigger("向右待機");
            }
            else
            {
                //PlayerRd.MoveRotation(180);
                // PlayerSP.flipY = true;
                PlayerAni.SetTrigger("向左待機");
            }
        }
        else
        {
            if (npc.position.y >= transform.position.y)
            {
                // PlayerRd.MoveRotation(90);
                PlayerAni.SetTrigger("向下待機");
            }
            else
            {
                // PlayerRd.MoveRotation(-90);
                PlayerAni.SetTrigger("待機");
            }
        }
        inDeadZoom = true;


    }
    private void FixedUpdate()
    {
        // if (inDeadZoom)
        // {
        //     StopMove();

        // }
    }
    private void Update()
    {
        if (canMove)
        {


            if (MoveUP)
            {
                PlayerTm.Translate(0, 1 * MoveSpeed * Time.deltaTime, 0, Space.World);
                // PlayerRd.MoveRotation(0);
                PlayerSP.flipY = false;

            }
            else if (MoveDown)
            {
                PlayerTm.Translate(0, -1 * MoveSpeed * Time.deltaTime, 0, Space.World);
                //PlayerRd.MoveRotation(180);
                standingPoint = transform.Find("Triangle (1)");
                PlayerSP.sprite = idel[0];


            }
            else if (MoveRight)
            {
                PlayerTm.Translate(1 * MoveSpeed * Time.deltaTime, 0, 0, Space.World);
                //PlayerRd.MoveRotation(-90);
                standingPoint = transform.Find("Triangle (3)");
                PlayerSP.sprite = idel[2];
            }
            else if (MoveLeft)
            {
                PlayerTm.Translate(-1 * MoveSpeed * Time.deltaTime, 0, 0, Space.World);
                //PlayerRd.MoveRotation(90);
                standingPoint = transform.Find("Triangle (2)");
                PlayerSP.sprite = idel[1];
            }
            else
            {
                // PlayerTm.position = new Vector3(PlayerTm.position.x, PlayerTm.position.y, PlayerTm.position.z);
            }
            PlayerTm.position = new Vector3(Mathf.Clamp(PlayerTm.position.x, -5.41f, 5.47f), Mathf.Clamp(PlayerTm.position.y, -3.11f, 2.10f), PlayerTm.position.z);

        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (!hit.CompareTag("Player") || !hit.CompareTag("傳送門"))
        {

            canMove = false;
            MoveSpeed=-MoveSpeed;
            
            print(hit.name);
        }
        if (hit.name == "會議室A" || hit.name == "會議室B")
        {
            GameObject[] ChangeItem = GameObject.FindGameObjectsWithTag("資料文件");
            if (ChangeItem.Length == 0) return;
            else
            {

                for (int i = 0; i < ChangeItem.Length; i++)
                {
                    Destroy(ChangeItem[i], 0.5f);
                    //GM.CanUse = true;

                }
                if (hit.name == "會議室A")
                {

                }
                else
                {
                    GameObject[] B = GameObject.FindGameObjectsWithTag("資料生成位置B");
                    for (int i = 0; i < B.Length; i++)
                    {
                        B[i].GetComponent<SpriteRenderer>().enabled = true;
                    }

                }
                GM.QuestClear("任務C", "會議室A");
                for (int i = 0; i < 3; i++)
                {
                    GameObject QT = GameObject.Find("請將資料發放置會議室A");
                    Destroy(QT, 0.2f);
                }


            }


        }
        if (hit.tag == "咖啡機")
        {
            GameObject[] ChangeItem = GameObject.FindGameObjectsWithTag("咖啡杯");
            if (ChangeItem == null) return;
            else
            {
                for (int i = 0; i < ChangeItem.Length; i++)
                {
                    ChangeItem[i].GetComponent<Animator>().SetBool("裝滿", true);

                }
            }



        }

    }
    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.tag == "CheckZone")
        {
            GM.CanUse = true;
        }
    }
  private void OnTriggerExit2D(Collider2D hit) 
  { 
      if (!hit.CompareTag("Player") || !hit.CompareTag("傳送門"))
        {

            canMove = true;
            MoveSpeed=-MoveSpeed;
        
    }
  }

}

#endregion

