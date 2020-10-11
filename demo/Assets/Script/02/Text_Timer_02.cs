using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Timer_02 : MonoBehaviour
{
    float tBegin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playing_AI_02.game_state2 == 0)
        {
            this.gameObject.SetActive(false);
            return;
        }

        float temp = Time.time - tBegin;

        //当前时间字符串
        string tempStr = temp.ToString();

        //整数部分
        string tempStr1 = ((int)temp).ToString();
        //小数部分，只保留小数点后2位
        string tempStr2;
        int index = tempStr.IndexOf(".");
        if (index == -1)
        {
            tempStr2 = tempStr + ".00";
        }
        else
        {
            if(tempStr.Length - index - 1 < 2)
            {
                tempStr2 = tempStr.Substring(index + 1, 1);
                tempStr2 += "0";
            }
            else
            {
                tempStr2 = tempStr.Substring(index + 1, 2);
            }

            /*int Num = 0;
            int.TryParse(tempStr2, out Num);
            if (Num < 10)
            {
                tempStr2 = "0" + tempStr;
            }*/
        }

        tempStr = tempStr1 + "." + tempStr2;

        //分钟
        int min = (int)(temp / 60);
        //秒
        int sec = (int)(temp) - min * 60;
        tempStr = tempStr + " (" + min + "分" + sec + "秒)";
        

        this.GetComponent<Text>().text = tempStr;
        Playing_AI_02.strTime = tempStr;
    }

    void Begin()
    {
        tBegin = Time.time;
    }
}
