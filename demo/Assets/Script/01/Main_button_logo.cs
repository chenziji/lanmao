using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_button_logo : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
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
        //从18个随机图随机一个
        int index = Random.Range(1, 18);
        string strPicture;
        if (index < 10)
        {
            strPicture = "picture/01/A0" + index.ToString();
        }
        else
        {
            strPicture = "picture/01/A" + index.ToString();
        }

        this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPicture);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("picture/01/A00icon");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

    }
}
