using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_chick_error : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playing_AI.game_state == 0)
        {
            this.gameObject.SetActive(false);
            return;
        }

        string tempStr = Playing_AI.game_chick_error.ToString();
        this.GetComponent<Text>().text = "错误操作次数: " + tempStr;
    }
}
