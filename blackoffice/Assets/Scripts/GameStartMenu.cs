using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    #region 屬性
    public GameObject InputNameField;
    public GameObject OKButton;
    [Header("輸入文字區域")]
    public InputField _InputFieldText;
    public string NextSceneName;
    public Animator Textaim;
    // public int InputTextCount;
    #endregion
    #region 方法

    public void QuitGameButton()
    {

        Application.Quit();
    }
    public void OpenInputField()
    {
        InputNameField.SetActive(true);
        OKButton.SetActive(true);
        OKButton.GetComponent<Button>().interactable = false;
    }
    public void OnOKButtonClick()
    {
        SceneManager.LoadScene(NextSceneName);
    }
    #endregion
    #region 事件
    private void Awake()
    {
        InputNameField.SetActive(false);
        OKButton.SetActive(false);
        // Textaim = GameObject.Find("
    }
    private void Update()
    {
        if (_InputFieldText.text != (""))
        {
            OKButton.GetComponent<Button>().interactable = true;
        }

    }
    #endregion

}
