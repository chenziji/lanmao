using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_Play : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    private GameObject gb_UI_Text_Timer;
    private GameObject gb_UI_Text_chick;
    private GameObject gb_UI_Text_chick_right;
    private GameObject gb_UI_Text_chick_error;

    // Start is called before the first frame update
    void Start()
    {
        gb_UI_Text_Timer = GameObject.Find("timer");
        gb_UI_Text_Timer.SendMessage("Init");
        gb_UI_Text_Timer.SetActive(false);

        gb_UI_Text_chick = GameObject.Find("chick");
        gb_UI_Text_chick.SetActive(false);

        gb_UI_Text_chick_right = GameObject.Find("chick_right");
        gb_UI_Text_chick_right.SetActive(false);

        gb_UI_Text_chick_error = GameObject.Find("chick_error");
        gb_UI_Text_chick_error.SetActive(false);

        //初始化socket
        BCI_Socket.Instance.Init();

        BCI_Socket.Instance.SendMsg("M_Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    { }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.activeInHierarchy == true)
        {
            this.gameObject.SetActive(false);
        }

        GameObject temp = GameObject.Find("Playing");

        Playing_AI.gb_UI_Playing.SetActive(true);
        Playing_AI.gb_UI_Main.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_HowToPlay.SetActive(false);
        //temp.GetComponent<Playing_AI>().gb_bt_PlayMoreGame.SetActive(false);

        //共有函数调用
        temp.GetComponent<Playing_AI>().Init();

        //私有函数调用
        //temp.SendMessage("Init");

        Playing_AI.game_state = 1;

        Playing_AI.game_chick = 0;
        Playing_AI.game_chick_right = 0;
        Playing_AI.game_chick_error = 0;

        Playing_AI.m_Success = 0;

        Playing_AI.iReverseA = 0;
        Playing_AI.iReverseB = 0;
        Playing_AI.gb_ReverseA = null;
        Playing_AI.gb_ReverseB = null;


        gb_UI_Text_Timer.SetActive(true);
        gb_UI_Text_Timer.SendMessage("Begin");

        gb_UI_Text_chick.SetActive(true);
        gb_UI_Text_chick_right.SetActive(true);
        gb_UI_Text_chick_error.SetActive(true);

        //隐藏logo
        temp.GetComponent<Playing_AI>().gb_bt_logo01.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_logo02.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_logo03.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_logo04.SetActive(false);
    }
}