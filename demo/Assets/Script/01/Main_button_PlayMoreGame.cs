using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_PlayMoreGame : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    private GameObject gb_UI_Main;
    private GameObject gb_bt_Play;
    private GameObject gb_bt_HowToPlay;

    // Start is called before the first frame update
    void Start()
    {
        gb_UI_Main = GameObject.Find("main");
        gb_bt_Play = GameObject.Find("main_play");
        gb_bt_HowToPlay = GameObject.Find("main_howtoplay");
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

        if (gb_UI_Main)
        {
            gb_UI_Main.SetActive(false);
        }
        if (gb_bt_Play)
        {
            gb_bt_Play.SetActive(false);
        }
        if (gb_bt_HowToPlay)
        {
            gb_bt_HowToPlay.SetActive(false);
        }
    }
}
