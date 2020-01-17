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

    public GameObject[] MoveButton;
    public Rigidbody2D PlayerRd;
    public Transform PlayerTm;
    public bool MoveUP = false;
    public bool MoveDown = false;
    public bool MoveRight = false;
    public bool MoveLeft = false;
    public int ButtonIndex;
    public Collider2D DeadZoom;
    public Transform standingPoint;
    public bool inDeadZoom;



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




    public void OnMoveUpDown()
    {
        MoveUP = true;
        // _moveCoroutine = StartCoroutine(Move(Vector2.up));
    }

    public void OnMoveUpUp()
    {
        MoveUP = false;
        // StopCoroutine(_moveCoroutine);
    }


    public void OnMoveDownDown()
    {

        MoveDown = true;
        // _moveCoroutine = StartCoroutine(Move(Vector2.down));
    }

    public void OnMovedownUp()
    {
        MoveDown = false;
        // StopCoroutine(_moveCoroutine);
    }


    public void OnMoverightDown()
    {
        MoveRight = true;
        // _moveCoroutine = StartCoroutine(Move(Vector2.right));

    }

    public void OnMoverightUp()
    {
        MoveRight = false;
        // StopCoroutine(_moveCoroutine);

    }



    public void OnMoveleftDown()
    {
        MoveLeft = true;
        // _moveCoroutine = StartCoroutine(Move(Vector2.left));
    }

    public void OnMoveleftUp()
    {
        MoveLeft = false;
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
                PlayerRd.MoveRotation(0);
            }
            else
            {
                PlayerRd.MoveRotation(180);

            }
        }
        else
        {
            if (npc.position.y >= transform.position.y)
            {
                PlayerRd.MoveRotation(90);
            }
            else
            {
                PlayerRd.MoveRotation(-90);
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
        if (MoveUP)
        {
            PlayerTm.Translate(0, 1 * MoveSpeed * Time.deltaTime, 0, Space.World);
            PlayerRd.MoveRotation(90);
        }
        else if (MoveDown)
        {
            PlayerTm.Translate(0, -1 * MoveSpeed * Time.deltaTime, 0, Space.World);
            PlayerRd.MoveRotation(-90);
        }
        else if (MoveRight)
        {
            PlayerTm.Translate(1 * MoveSpeed * Time.deltaTime, 0, 0, Space.World);
            PlayerRd.MoveRotation(0);
        }
        else if (MoveLeft)
        {
            PlayerTm.Translate(-1 * MoveSpeed * Time.deltaTime, 0, 0, Space.World);
            PlayerRd.MoveRotation(180);
        }
        else
        {
            // PlayerTm.position = new Vector3(PlayerTm.position.x, PlayerTm.position.y, PlayerTm.position.z);
        }
        PlayerTm.position = new Vector3(Mathf.Clamp(PlayerTm.position.x, -5.41f, 5.47f), Mathf.Clamp(PlayerTm.position.y, -3.11f, 2.10f), PlayerTm.position.z);


    }
}



#endregion

