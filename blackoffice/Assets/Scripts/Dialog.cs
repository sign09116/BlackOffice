using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    #region 屬性
    public List<string> Message;
    private int m_index = 0;
    private string _currentMessage;
    public float _charDisplayInterval = 0.25f;
    public  Text _text;
    public int _currentCharIndex;
    public int _currentSentenceCount;
    public GameObject sayingDialog;
    public int ponitdown;
   

    #endregion





    #region 方法
   


    public void NextMessage()
    {
        
        int charstarIndex = 1;
        ponitdown++;
        if (_currentCharIndex > _currentSentenceCount)
        {
            if (ponitdown <= Message.Count)
            {
                sayingDialog.SetActive(true);
                if (m_index < Message.Count)
                {
                    _currentMessage = Message[m_index++];

                }
                else
                {
                    charstarIndex = _currentSentenceCount;
                    _currentCharIndex = _currentSentenceCount;
                }
                StopAllCoroutines();
                StartCoroutine(DisplayMessage(charstarIndex));
            }
            
            else
            {
                OnDisable();
                ponitdown = 1;
            }
        }
        //StopAllCoroutines();
        //WaitForSeconds wait = new WaitForSeconds(1);
      
        

    }
    private IEnumerator DisplayMessage(int charIndex)
    {

        _currentSentenceCount = _currentMessage.Length;
        _currentCharIndex = charIndex;

        WaitForSeconds wait = new WaitForSeconds(_charDisplayInterval);
        while (_currentCharIndex <= _currentSentenceCount)
        {
            _text.text = _currentMessage.Substring(0, _currentCharIndex);
            _currentCharIndex++;
            yield return wait;
         }

    }

    private void OnDisable()
    {
        sayingDialog.SetActive(false);
    }


    #endregion





    #region 事件

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        
    }
    private void Start()
    {
        
       
    }
    private void Update()
    {
        
    }



    #endregion
}
