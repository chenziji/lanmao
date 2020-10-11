using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Playing_AI_02 : MonoBehaviour
{
    public static int game_level2 = 0;   //当前关卡

    public static int game_state2 = 0;   //游戏状态

    public static int game_chick = 0;   //点击次数
    public static int game_chick_right = 0;   //正确操作次数
    public static int game_chick_error = 0;   //错误操作次数

    public static int gb_prefab_Num = 18;   //预设数量
    public static int game_level_num = 3;   //游戏关卡数量
    int[] m_gb_level_num;         //游戏关卡/对象数量

    public static int iReverseA = 0;  //A翻转的ID
    public static int iReverseB = 0;  //B翻转的ID
    public static GameObject gb_ReverseA;  //A翻转的对象
    public static GameObject gb_ReverseB;  //B翻转的对象

    public static int m_Success = 0;   //成功的个数

    public static string strTime;   //用时

    float wight = 70, hight = 70; //单个元素宽高间隔

    private GameObject gb_GameObject_father;//父类
    private GameObject[] gb_playing_prefad;//预设
    private GameObject[] gb_playing;//实例

    //其他对象
    public GameObject gb_bt_PlayBegin;
    public GameObject gb_bt_PlayMoreGame;
    public GameObject gb_bt_PlayAgain;
    public GameObject gb_bt_PlayMoreEnd;
    public GameObject gb_bt_Reset;

    public GameObject gb_UI_Main;
    public GameObject gb_UI_Playing;
    public GameObject gb_UI_End;

    string str1 = "";
    string str2 = "Sprite_";
    string str = "";

    // Start is called before the first frame update
    void Start()
    {
        gb_GameObject_father = GameObject.Find("GameObject");

        gb_bt_PlayBegin = GameObject.Find("main_play");
        gb_bt_PlayMoreGame = GameObject.Find("main_play_more_game");
        gb_bt_PlayAgain = GameObject.Find("end_play_again");
        gb_bt_PlayMoreEnd = GameObject.Find("end_play_more");
        gb_bt_Reset = GameObject.Find("reset");

        gb_UI_Main = GameObject.Find("main");
        gb_UI_Playing = GameObject.Find("playing");
        gb_UI_End = GameObject.Find("end");

        gb_UI_Playing.SetActive(false);
        gb_UI_End.SetActive(false);
        gb_bt_PlayAgain.SetActive(false);
        gb_bt_PlayMoreEnd.SetActive(false);
        gb_bt_Reset.SetActive(false);

        if (gb_UI_Playing)
        {
            gb_UI_Playing.SetActive(false);
        }

        gb_playing_prefad = new GameObject[gb_prefab_Num];

        //每关对象数量
        m_gb_level_num = new int[game_level_num];
        for (int i = 0; i < game_level_num; ++i)
        {
            switch (i)
            {
                case 0:
                    {
                        //3x3
                        m_gb_level_num[i] = 9;
                    }
                    break;
                case 1:
                    {
                        m_gb_level_num[i] = 9;
                    }
                    break;
                case 2:
                    {
                        m_gb_level_num[i] = 12;
                    }
                    break;
                case 3:
                    {
                        m_gb_level_num[i] = 16;
                    }
                    break;
                default:
                    break;
            }
        }

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

    }

    public void Init()
    {
        gb_bt_Reset.SetActive(true);

        gb_playing = new GameObject[m_gb_level_num[game_level2]];


        IList<int> listRandom = new List<int>(m_gb_level_num[game_level2]);  //随机表
        //添加随机数组
        for (int i = 1; i <= m_gb_level_num[game_level2]; ++i)
        {
            listRandom.Add(i);
        }

        int w = 0, h = 0;

        int create_playing_left = m_gb_level_num[game_level2];
        //从数组中随机2个
        while (listRandom.Count > 0)
        {
            //随机是哪个预设
            int prefabNum = Random.Range(1, gb_prefab_Num);

            for (int num = 0; num < 3; ++num)
            {
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
                switch (game_level2)
                {
                    case 0:
                        {
                            //3x3
                            if (irand % 3 == 0)
                            {
                                h = irand / 3;
                            }
                            else
                            {
                                h = irand / 3 + 1;
                            }
                            w = irand - (h - 1) * 3;

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
                                gb_playing[irand - 1].transform.position = new Vector3(gb_UI_Main.transform.position.x - 50 + w * wight, gb_UI_Main.transform.position.y - 50 + h * hight, 0);
                                gb_playing[irand - 1].SetActive(true);
                                // gb_playing[irand - 1].GetComponent<Image>().material = null;
                            }
                        }
                        break;
                    case 1:
                        {

                        }
                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {

                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    void GameEnd()
    {
        Log(true);

        //显示结束UI
        gb_UI_End.SetActive(true);
        //显示button
        gb_bt_PlayAgain.SetActive(true);
        gb_bt_PlayMoreEnd.SetActive(true);
        //隐藏所有游戏对象
        //for (int i = 0; i < gb_playing_Num; ++i)
        //{
        //    Destroy(gb_playing[i]);
        //}

        //隐藏UI
        gb_UI_Playing.SetActive(false);
        gb_bt_Reset.SetActive(false);

        game_state2 = 0;
    }

    public void GameReset()
    {
        //显示隐藏UI
        gb_UI_Playing.SetActive(false);
        gb_UI_End.SetActive(false);
        gb_UI_Main.SetActive(true);
        //显示隐藏button
        gb_bt_PlayAgain.SetActive(false);
        gb_bt_PlayMoreEnd.SetActive(false);
        gb_bt_PlayBegin.SetActive(true);
        gb_bt_PlayMoreGame.SetActive(true);
        gb_bt_Reset.SetActive(false);

        //隐藏所有游戏对象
        //for (int i = 0; i < gb_playing_Num; ++i)
        //{
        //    Destroy(gb_playing[i]);
        //}

        game_state2 = 0;
    }

    public static void Log(bool b)
    {
        //Application.dataPath 数据路径

        string path = "GameLog日志";            //默认在工程目录下创建
        //创建文件夹
        if (Directory.Exists(path) == false)
        {
            //Directory.CreateDirectory(Application.dataPath + "GameLog日志");   //只有当文件不存在的话，创建新文件
            Directory.CreateDirectory(path);
        }

        //创建txt
        //StreamWriter sw = new StreamWriter(Application.dataPath + "GameLog日志//Log_短时记忆01.txt", true);
        StreamWriter sw = new StreamWriter(path + "//Log_短时记忆02.txt", true);

        GameObject temp = GameObject.Find("timer_begin");

        //开始写入
        sw.WriteLine("");
        sw.WriteLine("短时记忆02  " + System.DateTime.Now.ToString());
        if (b)
        {
            sw.WriteLine("类型: 成功");
        }
        else
        {
            sw.WriteLine("类型: 失败");
        }
        sw.WriteLine("点击次数: " + game_chick);
        sw.WriteLine("用时" + strTime);
        sw.WriteLine("正确操作次数: " + game_chick_right);
        sw.WriteLine("错误操作次数: " + game_chick_error);
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
    }
}
