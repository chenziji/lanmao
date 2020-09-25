using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playing_AI : MonoBehaviour
{
    public static int game_state = 0;   //游戏状态

    public static int gb_prefab_Num = 18;   //预设数量
    public static int gb_playing_Num = 64;  //游戏对象数量

    public static int iReverseA = 0;  //A翻转的ID
    public static int iReverseB = 0;  //B翻转的ID
    public static GameObject gb_ReverseA;  //A翻转的对象
    public static GameObject gb_ReverseB;  //B翻转的对象

    public static int m_Success = 0;   //成功的个数

    int m_per_line_num = 8;    //每排数量
    float posx = 0, posy = 0; //初始坐标
    float wight = 55, hight = 55; //单个元素宽高间隔
    IList<int> listRandom = new List<int>(gb_playing_Num);  //随机表

    private GameObject gb_GameObject_father;//父类
    private GameObject[] gb_playing_prefad;//预设
    private GameObject[] gb_playing;//实例
    private GameObject gb_GameObject_BG;//背景图

    string str1 = "";
    string str2 = "Sprite_";
    string str = "";

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(640, 960, false);

        gb_GameObject_BG = GameObject.Find("main");
        posx = gb_GameObject_BG.transform.position.x - 190;
        posy = gb_GameObject_BG.transform.position.y - 205;

        gb_playing_prefad = new GameObject[gb_playing_Num];

        //预设初始化显示false
        for (int i = 1; i <= gb_prefab_Num; ++i)
        {
            if (i <= 9)
            {
                str1 = "Sprite_0";
                str1 += i.ToString();
                str = str1;
            }
            else
            {
                str2 = "Sprite_";
                str2 += i.ToString();
                str = str2;
            }

            gb_playing_prefad[i - 1] = GameObject.Find(str);
            if (!gb_playing_prefad[i - 1])
            {
                continue;
            }

            //设置激活状态为flase后，该组件不会再被 find
            gb_playing_prefad[i - 1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.mousePosition.x;
        float vertical = Input.mousePosition.y;
        print("【x】:" + horizontal + "【y】:" + vertical);

        if (game_state == 1)
        {
            if (gb_ReverseA && gb_ReverseB)
            {
                if (iReverseA != 0 && iReverseB != 0 )
                {
                    if (iReverseA != iReverseB)
                    {
                        gb_ReverseA.GetComponent<Perfab_01>().bEnd = true;
                        gb_ReverseB.GetComponent<Perfab_01>().bEnd = true;
                        //延迟
                        //Invoke("Back", 0.5f);
                        //没有翻转到同一个

                        //Invoke("Back2", 1.0f);
                    }
                    else
                    {
                        ++m_Success;
                        if(m_Success == gb_playing_Num)
                        {
                            GameEnd();
                        }
                    }
                    iReverseA = 0;
                    iReverseB = 0;
                    gb_ReverseA = null;
                    gb_ReverseB = null;
                }
            }  
        }
    }

    void Back()
    {
        gb_ReverseA.GetComponent<Perfab_01>().bEnd = true;
        gb_ReverseB.GetComponent<Perfab_01>().bEnd = true;
    }

    void Back2()
    {
        iReverseA = 0;
        iReverseB = 0;
    }

    void Init()
    {
        gb_GameObject_father = GameObject.Find("GameObject");
        gb_playing = new GameObject[gb_playing_Num];

        //添加随机数组
        for (int i = 1; i <= gb_playing_Num; ++i)
        {
            listRandom.Add(i);
        }

        int w = 0, h = 0;

        int create_playing_left = gb_playing_Num;
        //从数组中随机2个
        while (listRandom.Count > 0)
        {
            for (int num = 0; num < 2; ++num)
            {
                //随机是哪个预设
                int prefabNum = Random.Range(1, gb_prefab_Num);

                //从数组中剩余元素随机
                //随机到索引
                int index = Random.Range(1, create_playing_left);
                //获取索引值
                index -= 1;
                int irand = listRandom[index];
                //删除随机列表中的元素
                listRandom.RemoveAt(index);
                //计数减1
                --create_playing_left;

                //计算排数x,y
                if (irand % m_per_line_num == 0)
                {
                    h = irand / m_per_line_num;
                }
                else
                {
                    h = irand / m_per_line_num + 1;
                }
                w = irand - (h - 1) * m_per_line_num;

                //从0计数
                --h;
                --w;

                if (!gb_playing_prefad[prefabNum])
                {
                    break;
                }

                //创建实例
                gb_playing[irand - 1] = Instantiate<GameObject>(gb_playing_prefad[prefabNum]);
                if (gb_playing[irand - 1])
                {
                    gb_playing[irand - 1].transform.SetParent(gb_GameObject_father.transform);
                    gb_playing[irand - 1].transform.position = new Vector3(posx + w * wight, posy + h * hight, 0);
                    gb_playing[irand - 1].SetActive(true);
                   // gb_playing[irand - 1].GetComponent<Image>().material = null;
                }
            }
        }
    }

    void GameEnd()
    {

    }
}
