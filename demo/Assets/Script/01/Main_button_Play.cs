using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_Play : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
       
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

        temp.GetComponent<Playing_AI>().gb_UI_Playing.SetActive(true);
        temp.GetComponent<Playing_AI>().gb_UI_Main.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_HowToPlay.SetActive(false);
        temp.GetComponent<Playing_AI>().gb_bt_PlayMoreGame.SetActive(false);

        temp.GetComponent<Playing_AI>().Init();

        //temp.SendMessage("Init");

        Playing_AI.game_state = 1;
        Playing_AI.m_Success = 0;

        Playing_AI.iReverseA = 0;
        Playing_AI.iReverseB = 0;
        Playing_AI.gb_ReverseA = null;
        Playing_AI.gb_ReverseB = null;
    }
}
