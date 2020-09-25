using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_Play : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    private GameObject gb_UI_Main;
    private GameObject gb_bt_HowToPlay;
    private GameObject gb_bt_PlayMoreGame;

    private GameObject gb_UI_Playing;

    // Start is called before the first frame update
    void Start()
    {
        gb_UI_Main = GameObject.Find("main");
        gb_bt_HowToPlay = GameObject.Find("main_howtoplay");
        gb_bt_PlayMoreGame = GameObject.Find("main_play_more_game");

        gb_UI_Playing = GameObject.Find("playing");

        if (gb_UI_Playing)
        {
            gb_UI_Playing.SetActive(false);
        }
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

        gb_UI_Main.SetActive(false);
        gb_bt_HowToPlay.SetActive(false);
        gb_bt_PlayMoreGame.SetActive(false);

        if (gb_UI_Playing)
        {
            gb_UI_Playing.SetActive(true);
        }

        Playing_AI.game_state = 1;
        GameObject temp = GameObject.Find("Playing");
        temp.SendMessage("Init");

        Playing_AI.m_Success = 0;
    }
}
