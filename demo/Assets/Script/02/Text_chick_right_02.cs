using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_chick_right_02 : MonoBehaviour
{
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

        this.GetComponent<Text>().text = Playing_AI_02.game_chick_right.ToString();
    }
}
