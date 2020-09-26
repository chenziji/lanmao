using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_PlayAgain : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        GameObject temp = GameObject.Find("Playing");
        temp.GetComponent<Playing_AI>().GameReset();
    }

}
