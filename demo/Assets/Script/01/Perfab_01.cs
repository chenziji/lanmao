using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Perfab_01 : MonoBehaviour, IPointerDownHandler
{
    bool bBegin = false;
    public bool bEnd = false;
    Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
    Quaternion targetRotationBack = Quaternion.Euler(0, 0, 0);
    //float speedZ = 30;

    string strPicture;
    string strPictureBack = "picture/01/A00";

    //调用其他脚本变量 非static
    //GameObject a = GameObject.Find("Playing_AI");
    //a.GetComponent<Playing_AI>().m_per_line_num = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(bBegin)
        {
            Begin();
        }
        else if(bEnd)
        {
            End();
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if(Playing_AI.iReverseA != 0 && Playing_AI.iReverseB != 0)
        {
            return;
        }
        string strName = this.GetComponent<Component>().name;
        int index = strName.IndexOf('_');
        strName = strName.Substring(index + 1, 2);
        //string strMaterial = "Material_And_Shader/01/Material_" + strName;
        //this.GetComponent<Image>().material = Resources.Load<Material>(strMaterial);

        int _Num = 0;
        int.TryParse(strName, out _Num);

        strPicture = "picture/01/A" + strName;


        bBegin = true;

        if (Playing_AI.iReverseA == 0)
        {
            Playing_AI.gb_ReverseA = gameObject;
            Playing_AI.iReverseA = _Num;
        }
        else if (Playing_AI.iReverseA != 0 && Playing_AI.iReverseB == 0)
        {
            Invoke("Invoke", 0.5f);
            Playing_AI.iReverseB = _Num;
        }

    }

    void Invoke()
    {
        Playing_AI.gb_ReverseB = gameObject;
    }

    void Begin()
    {
        //翻转
        //慢慢旋转到指定角度
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * 10);

        if (this.transform.eulerAngles.y != 180)
        {
            if (this.transform.localEulerAngles.y <= 181)
            {
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);

                bBegin = false;
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 930);
            }

            if (this.transform.localEulerAngles.y > 250 && this.transform.localEulerAngles.y < 290)
            {
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPicture);
            }
                
            /*else
            {
                float temp = this.transform.position.z;
                if (this.transform.position.z < 900)
                {
                    temp += speedZ;
                }
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, temp);
            }*/
        }
        else
        {
            bBegin = false;
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 930);
        }
    }

    void End()
    {
        //翻转回去

        //慢慢旋转到指定角度
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotationBack, Time.deltaTime * 10);

        if (this.transform.eulerAngles.y != 0)
        {
            if (this.transform.localEulerAngles.y <= 1)
            {
                this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);

                bEnd = false;
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                //this.GetComponent<Image>().material = null;
            }
            if (this.transform.localEulerAngles.y > 250 && this.transform.localEulerAngles.y < 290)
            {
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>(strPictureBack);
            }
            /*else
            {
                float temp = this.transform.position.z;
                if (this.transform.position.z > 0)
                {
                    temp -= speedZ;
                }
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, temp);
            }*/
        }
        else
        {
            bEnd = false;
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            //this.GetComponent<Image>().material = null;
        }
    }
}
