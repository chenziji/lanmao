using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Perfab_02 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
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
    {

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        string strName = this.GetComponent<Component>().name;
        int index = strName.IndexOf('_');
        strName = strName.Substring(index + 1, 2);
        //string strMaterial = "Material_And_Shader/01/Material_" + strName;
        //this.GetComponent<Image>().material = Resources.Load<Material>(strMaterial);

        int _Num = 0;
        int.TryParse(strName, out _Num);

        if (Playing_AI_02.iReverseA == 0 && Playing_AI_02.gb_ReverseA == null)
        {
            Playing_AI_02.gb_ReverseA = gameObject;
            Playing_AI_02.iReverseA = _Num;
            Playing_AI_02.game_chick += 1;

            //更换图片
            string strPicture = "picture/02/B" + strName;
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPicture);
        }
        else if (Playing_AI_02.iReverseA != 0 && Playing_AI_02.iReverseB == 0 && Playing_AI_02.gb_ReverseB == null)
        {
            Playing_AI_02.gb_ReverseB = gameObject;
            Playing_AI_02.iReverseB = _Num;
            Playing_AI_02.game_chick += 1;

            //更换图片
            string strPicture = "picture/02/B" + strName;
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPicture);
        }
        else if (Playing_AI_02.iReverseA != 0 && Playing_AI_02.iReverseB != 0 &&
            Playing_AI_02.iReverseC == 0 && Playing_AI_02.gb_ReverseC == null)
        {
            Playing_AI_02.iReverseC = _Num;
            Playing_AI_02.game_chick += 1;

            if (Playing_AI_02.iReverseA == _Num && Playing_AI_02.iReverseB == _Num)
            {
                Playing_AI_02.game_chick_right += 1;
            }
            else
            {
                Playing_AI_02.game_chick_error += 1;
            }

            //更换图片
            string strPicture = "picture/02/B" + strName;
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPicture);

            //延迟0.4秒
            Invoke("Invoke", 0.6f);
        }
    }

    void Invoke()
    {
        Playing_AI_02.gb_ReverseC = gameObject;
    }

    public void End()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("picture/02/B00");
    }
}
