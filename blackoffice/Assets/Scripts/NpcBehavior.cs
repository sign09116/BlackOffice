using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DT;


public class NpcBehavior : MonoBehaviour
{
    #region 屬性

    public GameObject Player;
    /// <summary>
    /// 玩家名稱
    /// </summary>
    string my_PlayerName;
    public Transform NpcTra;
    public Collider2D PlayerCo;
    public Transform PlayerTra;
    [Header("原始位置")]
    public Vector2 O_Position;
    [Header("NPC資料Data")]
    public NPCData N_Data;
    public float NPcSpeed;
    public bool IntoEye;
    public Rigidbody2D NPCrig;
    public SpriteRenderer NpcSp;
    [Header("任務回報區域")]
    public GameObject QuestCheckZone;
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
    // [Header("可發布任務")]
    // //public QuestData[] questData;
    /// <summary>
    /// 道具欄位置
    /// </summary>
    [Header("道具欄位置")]
    public Transform Itemblock;
    /// <summary>
    /// 給予任務ID
    /// </summary>
    public int Q;
    public GameObject NPcfxCanvas;
    [Header("NPC頭頂訊息")]
    public GameObject Npcfx1, Npcfx2, Npcfx3, Npcfx4;

    #endregion

    #region 方法
    public void NPcMove()
    {
        if (IntoEye)
        {

            //Direction = Vector2.left;
            //NPCrig.MovePosition(NPCrig.position + Direction * Time.deltaTime * NPcSpeed);
            Debug.Log("進入視線範圍");
            Npcaim.SetBool("Move", true);
            EyeBox.SetActive(false);
            IntoEye = false;
        }


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (GM.HaveQuest.Count >= 3 || N_Data.isQuest) return;



        if (collision.CompareTag("Player"))
        {


            collision = PlayerCo;

            IntoEye = true;
            randomPatrol2D.StopPatrol();
            Player.GetComponent<PlayerMovecontrol>().FaceNPC(transform);
            GM.maskObj.GetComponent<Image>().raycastTarget = true;


            StartCoroutine(MoveToPlayer());
            StartCoroutine(GiveQuest());
            Npcaim.SetBool("Move", false);



        }

    }

    private IEnumerator MoveToPlayer()
    {
        EyeBox.SetActive(false);
        Npcaim.SetBool("向上", false);
        Npcaim.SetBool("向下", false);
        Npcaim.SetBool("向左", false);
        Npcaim.SetBool("向右", false);
        Npcaim.SetBool("看上", false);
        Npcaim.SetBool("看下", false);
        Npcaim.SetBool("看左", false);
        Npcaim.SetBool("看右", false);
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



    // public void NpcReturnPosition()
    // {

    //     float disx = O_Position.x;
    //     float disy = O_Position.y;
    //     NPCrig.MovePosition(new Vector2(disx, disy) * Time.fixedDeltaTime);


    //     isreturn = true;



    // }
    #endregion



    #region 事件

    public void Awake()
    {
        playerMovecontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovecontrol>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCo = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        PlayerTra = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); ;
        GM = GameObject.FindObjectOfType<GameManager>();
        Itemblock = GameObject.Find("道具欄").transform;
        NpcSp = GetComponent<SpriteRenderer>();
        NPcfxCanvas = transform.GetChild(2).gameObject;
        Npcfx1 = GameObject.Find("NPCA頭頂訊息1");
        Npcfx2 = GameObject.Find("NPCA頭頂訊息2");
        Npcfx3 = GameObject.Find("NPCB頭頂訊息1");
        Npcfx4 = GameObject.Find("NPCB頭頂訊息2");

    }
    // Use this for initialization
    void Start()
    {
        if (GM.ReCheckMan != null)

        {

            for (int i = 0; i < 3; i++)
            {
                GM.FindCheckMan(GM.ReCheckMan[i]);
            }

            if (!GM.ReCheckMan.Contains(gameObject.name))
            {
                N_Data.isQuest = false;
                isreturn = true;
                isreturn = false;
            }
            else
            {
                isreturn = false;
            }
        }



        my_PlayerName = PlayerPrefs.GetString(GM.PlayerName);

    }

    // Update is called once per frame
    void Update()
    {


        NPcMove();
        NPcfxCanvas.transform.eulerAngles = new Vector3(0, 0, 0);

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

        N_Data.isQuest = true;
        Q = 0;
        Q = Random.Range(0, N_Data.Q_data.Count);
        Debug.Log("任務ID" + Q);
        yield return new WaitForSeconds(3f);
        GM.saydialog.SetActive(true);
        if (Q == 0)
        {
            int r = Random.Range(0, N_Data.returnNPC_Name.Count);
            // print(r);
            N_Data.Q_data[Q].checkMan = N_Data.returnNPC_Name[r];
            GM.saydialog.GetComponent<Dialog>().SpeakerName.text = gameObject.name;
            GM.saydialog.GetComponentInChildren<Text>().text = my_PlayerName + N_Data.Q_data[Q].Q_Massage[0] + N_Data.Q_data[Q].checkMan;
        }
        else if (Q == 1)
        {
            N_Data.Q_data[Q].checkMan = gameObject.name;
            GM.saydialog.GetComponent<Dialog>().SpeakerName.text = gameObject.name;
            GM.saydialog.GetComponentInChildren<Text>().text = my_PlayerName + N_Data.Q_data[Q].Q_Massage[0];
        }
        else
        {
            GM.saydialog.GetComponent<Dialog>().SpeakerName.text = gameObject.name;
            GM.saydialog.GetComponentInChildren<Text>().text = my_PlayerName + N_Data.Q_data[Q].Q_Massage[0];
        }

        Invoke("GiveReward", 1f);
        yield return new WaitForSeconds(1f);
        GM.maskObj.SetActive(false);
        GM.saydialog.SetActive(false);


        // NpcReturnPosition();
    }
    /// <summary>
    /// 給予道具
    /// </summary>
    public void GiveReward()
    {

        GameObject rewardItem = Instantiate(N_Data.Q_data[Q].RewardItem, Camera.main.transform.position, new Quaternion(0, 0, 0, 0));

        rewardItem.transform.SetParent(Itemblock);
        GM.HaveQuest.Add(N_Data.Q_data[Q].name);
        GM.ReCheckMan.Add(N_Data.Q_data[Q].checkMan);
        rewardItem.GetComponent<ItemManager>().GetItem(rewardItem.name, N_Data.Q_data[Q].name, N_Data.Q_data[Q].checkMan);//獲得道具名稱與來源

        GameObject MissionText = Instantiate(GM.MissionText, GM.Agendumobj.transform.position, Quaternion.identity);//任務內容生成
        MissionText.transform.SetParent(GM.Agendumobj.transform);
        if (Q == 0)
        {
            MissionText.name = N_Data.Q_data[Q].Q_Massage[0] + N_Data.Q_data[Q].checkMan;
        }
        else
        {
            MissionText.name = N_Data.Q_data[Q].Q_Massage[0];
        }

        MissionText.GetComponent<Text>().text = GM.saydialog.GetComponentInChildren<Text>().text;
        // print(N_Data.Q_data[Q].checkMan);


        waitQuestReurn();

    }

    public void waitQuestReurn()
    {
        if (GM.ReCheckMan.Contains(gameObject.name))
        {
            randomPatrol2D.StopPatrol();
        }
        else
        {
            isreturn = true;
            return;
        }


    }
    #endregion


}
