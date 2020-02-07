using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace DT
{
    public enum PatrolAction
    {


        GOForward, GOBackground, GoRight, GOLeft, TurnForward, TurnBackground, TurnRight, TurnLeft

    }
    [RequireComponent(typeof(Rigidbody2D))]
    public class RandomPatrol2D : MonoBehaviour
    {

        #region 屬性

        public float Randomtime = 0;
        public Vector2 _patrolAreaSize;
        public Rect patrolArea;
        private Vector3 _originalPosition;
        public Vector3 OriginalPosition
        {
            get { return _originalPosition; }

        }
        public float MoveSpeed = 1;
        public float patrolInterval = 1;
        [Header("行為比例")]
        public int goForWardPosition;
        public int goBackroundPosition;
        public int goRightPosition;
        public int goLeftdPosition;
        public int turnForwardPosition;
        public int turnBackgroundPosition;
        public int turnRightPosition;
        public int turnLeftPosition;
        [Header("行為總和")]
        public int actionSum;
        protected Rigidbody2D _Npcrigidbody2D;
        public NpcBehavior m_NPC;


        [SerializeField] private Transform _peak;

        #endregion


        #region 方法
        private List<PatrolAction> _actionPopulation = new List<PatrolAction>();
        private Dictionary<PatrolAction, Action> _patrolActions = new Dictionary<PatrolAction, Action>();


        private IEnumerator TakeNextRandomActionLoop()
        {
            // yield return new WaitForSeconds(1);
            WaitForFixedUpdate fixedwait = new WaitForFixedUpdate();
            while (true)
            {
                int index = UnityEngine.Random.Range(0, actionSum);
                PatrolAction action = _actionPopulation[index];
                float time = 0;
                while (time < Randomtime)
                {
                    _patrolActions[action]();
                    time += Time.fixedDeltaTime;
                    yield return fixedwait;
                }
            }
        }
        private void GoForward()
        {
            m_NPC.Npcaim.SetBool("向右", false);
            m_NPC.Npcaim.SetBool("向下", false);
            m_NPC.Npcaim.SetBool("向左", false);
            TurnForward();
            m_NPC.Npcaim.SetBool("看上", false);
            m_NPC.Npcaim.SetBool("向上", true);

            Vector2 delta = Vector2.up * MoveSpeed * Time.fixedDeltaTime;

            if (_peak.position.y + delta.y <= patrolArea.yMax)
            {
                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position + delta);

            }
            else
            {

                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position);

            }
            Debug.Log("GoForward");
        }
        private void GoBackground()
        {
            m_NPC.Npcaim.SetBool("向右", false);
            m_NPC.Npcaim.SetBool("向上", false);
            m_NPC.Npcaim.SetBool("向左", false);

            TurnBackground();
            m_NPC.Npcaim.SetBool("看下", false);
            m_NPC.Npcaim.SetBool("向下", true);

            Vector2 delta = Vector2.down * MoveSpeed * Time.fixedDeltaTime;

            if (_peak.position.y - delta.y >= patrolArea.yMin)
            {
                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position + delta);

            }
            else
            {

                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position);

            }
            Debug.Log("GoBackground");

        }
        private void GoRight()
        {
            m_NPC.Npcaim.SetBool("向上", false);
            m_NPC.Npcaim.SetBool("向下", false);
            m_NPC.Npcaim.SetBool("向左", false);

            TurnRight();
            m_NPC.Npcaim.SetBool("看右", false);
            m_NPC.Npcaim.SetBool("向右", true);

            Vector2 delta = Vector2.right * MoveSpeed * Time.fixedDeltaTime;

            if (_peak.position.x + delta.x <= patrolArea.xMax)
            {
                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position + delta);

            }
            else
            {

                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position);

            }
            Debug.Log("GoRight");
        }

        private void GoLeft()
        {
            m_NPC.Npcaim.SetBool("向上", false);
            m_NPC.Npcaim.SetBool("向下", false);
            m_NPC.Npcaim.SetBool("向右", false);
            TurnLeft();
            m_NPC.Npcaim.SetBool("看左", false);
            m_NPC.Npcaim.SetBool("向左", true);

            Vector2 delta = Vector2.left * MoveSpeed * Time.fixedDeltaTime;

            if (_peak.position.x + delta.x >= patrolArea.xMin)
            {

                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position + delta);
                //m_NPC.NpcSp.flipY = true;
            }
            else
            {

                _Npcrigidbody2D.MovePosition(_Npcrigidbody2D.position);

                //m_NPC.NpcSp.flipY = false;
            }
            Debug.Log("GoLeft");


        }
        private void TurnForward()
        {
            m_NPC.Npcaim.SetBool("看上", true);
            _Npcrigidbody2D.MoveRotation(0);
            Debug.Log("TurnForward " + _Npcrigidbody2D.transform.eulerAngles);
            m_NPC.NpcSp.flipY = false;
        }
        private void TurnBackground()
        {
            m_NPC.Npcaim.SetBool("看下", true);
            _Npcrigidbody2D.MoveRotation(180);

            Debug.Log("TurnBackground " + _Npcrigidbody2D.transform.eulerAngles);
            m_NPC.NpcSp.flipY = true;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            m_NPC.NPcfxCanvas.GetComponent<RectTransform>().rotation = rotation;
        }
        private void TurnRight()
        {
            m_NPC.Npcaim.SetBool("看右", true);
            _Npcrigidbody2D.MoveRotation(0);

            Debug.Log("TurnRight " + _Npcrigidbody2D.transform.eulerAngles);
            m_NPC.NpcSp.flipY = false;
        }
        private void TurnLeft()
        {
            m_NPC.Npcaim.SetBool("看左", true);
            _Npcrigidbody2D.MoveRotation(180);



            Debug.Log("TurnLeft " + _Npcrigidbody2D.transform.eulerAngles);
            m_NPC.NpcSp.flipY = true;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            m_NPC.NPcfxCanvas.GetComponent<RectTransform>().rotation = rotation;
        }
        #endregion



        #region 事件
        private void Awake()
        {
            _patrolActions[PatrolAction.GOForward] = GoForward;
            _patrolActions[PatrolAction.GOBackground] = GoBackground;
            _patrolActions[PatrolAction.GoRight] = GoRight;
            _patrolActions[PatrolAction.GOLeft] = GoLeft;
            _patrolActions[PatrolAction.TurnForward] = TurnForward;
            _patrolActions[PatrolAction.TurnBackground] = TurnBackground;
            _patrolActions[PatrolAction.TurnRight] = TurnRight;
            _patrolActions[PatrolAction.TurnLeft] = TurnLeft;
            _Npcrigidbody2D = GetComponent<Rigidbody2D>();
            m_NPC = GetComponent<NpcBehavior>();

        }

        private void OnEnable()
        {
            _originalPosition = transform.position;
            RestPatrolArea();
        }
        // Start is called before the first frame update
        void Start()
        {
            actionSum = goForWardPosition + goBackroundPosition + goRightPosition + goLeftdPosition + turnForwardPosition + turnBackgroundPosition + turnRightPosition + turnLeftPosition;
            int count = goForWardPosition;
            while (count-- > 0)
            {

                _actionPopulation.Add(PatrolAction.GOForward);

            }
            count = goBackroundPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.GOBackground);

            }
            count = goRightPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.GoRight);

            }
            count = goLeftdPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.GOLeft);

            }

            count = turnForwardPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.TurnForward);

            }
            count = turnBackgroundPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.TurnBackground);

            }
            count = turnRightPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.TurnRight);

            }
            count = turnLeftPosition;
            while (count-- > 0)
            {
                _actionPopulation.Add(PatrolAction.TurnLeft);

            }
            StarPatrol();
        }
        public void RestPatrolArea()
        {

            patrolArea = new Rect(transform.position.x - _patrolAreaSize.x * 0.5f, transform.position.y - _patrolAreaSize.y * 0.5f, _patrolAreaSize.x, _patrolAreaSize.y);

        }
        public void StarPatrol()

        {

            StartCoroutine(TakeNextRandomActionLoop());

        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion
#if UNITY_EDITOR
        private void OnValidate()
        {
            _originalPosition = transform.position;
            RestPatrolArea();
        }


#endif
        public void StopPatrol()
        {
            StopAllCoroutines();
        }

    }

}

