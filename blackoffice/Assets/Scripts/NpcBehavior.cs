using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DT;

public class NpcBehavior : MonoBehaviour
{
    #region 屬性

    public GameObject Player;
    public Transform NpcTra;
    public Collider2D PlayerCo;
    public Transform PlayerTra;
    public float NPcSpeed;
    public bool IntoEye;
    public Rigidbody2D NPCrig;
    public Vector2 Direction;
    public bool TouchPlayer;
    public Animator Npcaim;
    public GameObject EyeBox;
    public RandomPatrol2D randomPatrol2D;
    public PlayerMovecontrol playerMovecontrol;
    public float ReSeePlayer;
    public float ReSeePlayerMax;
    public bool isreturn;
    public bool isgivedquest;
    public BoxCollider2D standpoint;
    public BoxCollider2D Npctouch;
    public GameManager GM;
    [Header("可發布任務")]
    public QuestData[] questData;
    public Transform Itemblock;
    /// <summary>
    /// 給予任務ID
    /// </summary>
    public int Q;
    #endregion

    #region 方法
    public void NPcMove()
    {
        if (IntoEye)
        {
            //Direction = Vector2.left;
            //NPCrig.MovePosition(NPCrig.position + Direction * Time.deltaTime * NPcSpeed);
            Debug.Log("進入視線範圍");
            Npcaim.SetTrigger("Move");
            EyeBox.SetActive(false);
            IntoEye = false;
        }


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision = PlayerCo;

            IntoEye = true;
            randomPatrol2D.StopPatrol();
            Player.GetComponent<PlayerMovecontrol>().FaceNPC(transform);
            GM.maskObj.GetComponent<Image>().raycastTarget = true;
            StartCoroutine(MoveToPlayer());
            StartCoroutine(GiveQuest());


        }

    }

    private IEnumerator MoveToPlayer()
    {
        EyeBox.SetActive(false);
        Npcaim.SetTrigger("Move");
        WaitForFixedUpdate wait = new WaitForFixedUpdate();
        PlayerMovecontrol playerMoveControl = Player.GetComponent<PlayerMovecontrol>();
        Vector2 dir = playerMoveControl.standingPoint.position - transform.position;
        /*if (randomPatrol2D.goLeftdPosition != 0 || randomPatrol2D.goRightPosition != 0)
        {
            if (dir.x >= 0)
            {
                NPCrig.MoveRotation(0);
            }
            else
            {
                NPCrig.MoveRotation(180);
            }
        }*/
        dir = playerMoveControl.standingPoint.position - transform.position;
        dir = Mathf.Abs(dir.x) >= Mathf.Abs(dir.y) ? new Vector2(dir.x, 0) : new Vector2(0, dir.y);
        while (true)
        {
            NPCrig.MovePosition(NPCrig.position + dir.normalized * NPcSpeed * Time.fixedDeltaTime);
            if ((dir.x != 0 && Mathf.Abs(playerMoveControl.standingPoint.position.x - transform.position.x) < 0.01f) ||
                (dir.y != 0 && Mathf.Abs(playerMoveControl.standingPoint.position.y - transform.position.y) < 0.01f))
            {
                yield break;
            }
            TouchPlayer = true;
            //GM.Invoke("GiveReward", 5f);
            yield return wait;

        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    collision = PlayerCo;
    //    IntoEye = false;


    //}



    public void NpcReturnPosition()
    {
        NPCrig.MovePosition(randomPatrol2D.OriginalPosition);


        isreturn = true;



    }
    #endregion



    #region 事件

    public void Awake()
    {
        playerMovecontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovecontrol>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCo = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        PlayerTra = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); ;
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


        NPcMove();

    }
    private void FixedUpdate()
    {

        if (isreturn)
        {
            ReSeePlayer++;
            if (ReSeePlayer >= ReSeePlayerMax)
            {
                ReSeePlayer = 0;
                EyeBox.SetActive(true);
                randomPatrol2D.StarPatrol();

            }
        }

    }
   /// <summary>
   /// 給予任務
   /// </summary>
   /// <returns></returns>
    public IEnumerator GiveQuest()
    {
        Q = Random.Range(0, questData.Length);
        Debug.Log("任務ID" + Q);
        yield return new WaitForSeconds(3f);
        GM.saydialog.SetActive(true);
        GM.saydialog.GetComponentInChildren<Text>().text = questData[Q].Q_Massage[0];
        Invoke("GiveReward", 1f);
        yield return new WaitForSeconds(1f);
        GM.maskObj.SetActive(false);
        GM.saydialog.SetActive(false);
        
    }
   /// <summary>
   /// 給予道具
   /// </summary>
    public void GiveReward()
    {
        GameObject rewardItem = Instantiate(questData[Q].RewardItem, Camera.main.transform.position, new Quaternion(0, 0, 0, 0));
        rewardItem.transform.SetParent(Itemblock);
        

    }
    #endregion


}
