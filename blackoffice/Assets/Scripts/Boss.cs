using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Animator BossAni;
    public GameManager GM;

    private void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
        BossAni = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D hitPlayer)
    {
        if (hitPlayer.tag == "Player")
        {
            GM.saydialog.SetActive(true);
            hitPlayer.GetComponent<PlayerMovecontrol>().canMove = false;
            BossAni.SetBool("向右", true);
            GM.saydialog.GetComponent<Dialog>()._text.text = "君辛苦了。";
            hitPlayer.GetComponent<PlayerMovecontrol>().canMove = true;
        }

    }
    private void OnTriggerExit2D(Collider2D hitPlayer)
    {
        if (hitPlayer.tag == "Player")
        {
            BossAni.SetBool("向右", false);
            GM.saydialog.SetActive(false);

        }
    }
}
