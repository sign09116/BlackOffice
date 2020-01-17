using System.Collections;
using UnityEngine;
using UnityEditor;
namespace DT
{
    [CustomEditor(typeof(RandomPatrol2D))]
    public class RandomPatrol2Dscene : Editor
    {




        #region 屬性






        #endregion

        #region 方法







        #endregion


        #region 事件

        private void OnSceneGUI()
        {
            Handles.color = Color.green;
            RandomPatrol2D patrol2D = target as RandomPatrol2D;
            Rect _rect;
            if (Application.isPlaying)
            {
                _rect = new Rect(patrol2D.OriginalPosition.x - patrol2D._patrolAreaSize.x * 0.5f, patrol2D.OriginalPosition.y - patrol2D._patrolAreaSize.y * 0.5f, patrol2D._patrolAreaSize.x, patrol2D._patrolAreaSize.y);
            }
            else
            {

                _rect = new Rect(patrol2D.transform.position.x - patrol2D._patrolAreaSize.x * 0.5f, patrol2D.transform.position.y - patrol2D._patrolAreaSize.y * 0.5f, patrol2D._patrolAreaSize.x, patrol2D._patrolAreaSize.y);
                patrol2D.patrolArea = _rect;

            }
            Handles.DrawSolidRectangleWithOutline(_rect, new Color(0.0f, 1.0f, 0.0f, 0.125f), Color.black);
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





}
     