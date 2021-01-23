using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用法：1.在游戏启动时，调用Init（）
///     2.在合适的位置，调用 BCI_Socket.Instance.SendMsg(字符串)；
///     3.一般的，这个链接需要保持到游戏exe退出
/// </summary>


public class BCI_Socket : MonoBehaviour
{
    private Socket socketSend;
    public string ServerIP = "127.0.0.1";       //每台电脑上都有一个脑机搜集程序，故为为127.0.0.1
    public int ServerPort = 60000;
    [HideInInspector]public bool IsConneted = false;
    public bool IsAscii = false;          //经实验，目标格式为UTF8

    public static BCI_Socket _instance = null;
    public static BCI_Socket Instance       //一个全生命周期的数据
    {
        get
        {            
            if (_instance == null)
            {
                _instance = FindObjectOfType<BCI_Socket>() as BCI_Socket; //
                if (_instance == null)
                {
                    GameObject go = new GameObject("_BCI_SOCKET_");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<BCI_Socket>();
                }
            }            
            return _instance;
        }
    }

    public Button TestConnect;     //测试按钮
    public Button TestSend;

    public void Init()
    {
        StartClient();
    }

    public void Awake()
    {
        //_instance = this;
        //DontDestroyOnLoad(_instance.gameObject);

        //测试函数
        if (TestSend != null)
        {
            TestSend.GetComponent<Button>().onClick.AddListener(TestSendMsg);
        }
        
        if(TestConnect)
        {
            TestConnect.GetComponent<Button>().onClick.AddListener(StartClient);
        }
        

        Debug.Log("BCI_Socket Awake");
    }

    private void Start()
    {
        StartClient();

        Debug.Log("BCI_Socket Start");
    }
    
    public void StartClient()
    {
        if(IsConneted)
        {
            Debug.Log("BCI_Socket Already Connected");
            return;
        }

        try
        {
            //创建客户端Socket，获得远程ip和端口号
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(ServerIP);
            IPEndPoint point = new IPEndPoint(ip, ServerPort);

            socketSend.Connect(point);
            Debug.Log("连接成功!");

            //开启新的线程，不停的接收服务器发来的消息
            Thread c_thread = new Thread(Received);
            c_thread.IsBackground = true;
            c_thread.Start();
            Debug.Log("连接脑机服务器成功");
            IsConneted = true;

            if(bl_LobbyUI.Instance)
            {
                bl_LobbyUI.Instance.SetBCIState(true);
            }
            
        }
        catch (Exception)
        {
            Debug.LogError("链接脑机服务器失败...");
            IsConneted = false;

            if (bl_LobbyUI.Instance)
            {
                bl_LobbyUI.Instance.SetBCIState(false);
            }
        }
    }


    public void TestSendMsg()
    {
        SendMsg("测试内容");
    }

    //发送数据
    public void SendMsg(string str)
    {
        if(IsConneted)
        {
            try
            {
                string msg = str;
                byte[] buffer = new byte[1024 * 1024 * 3];
                if(IsAscii)
                {
                    buffer = Encoding.ASCII.GetBytes(msg);
                }
                else
                {
                    buffer = Encoding.UTF8.GetBytes(msg);
                }
                
                int i = socketSend.Send(buffer);

                Debug.LogFormat("BCI_Socket 发送{0} : {1}", i, buffer);
            }
            catch
            {
                Debug.LogError("BCI_Socket 向脑机服务器发送消息错误！");
            }
        }
    }

    /// <summary>
    /// 接收服务端返回的消息
    /// </summary>
    void Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                
                int len = socketSend.Receive(buffer);//实际接收到的有效字节数
                if (len == 0)
                {
                    break;
                }

                string str;
                if (IsAscii)
                {
                    str = Encoding.ASCII.GetString(buffer, 0, len);
                }
                else
                {
                    str = Encoding.UTF8.GetString(buffer, 0, len);
                }
                Debug.Log("客户端收到回复：" + socketSend.RemoteEndPoint + ":" + str);
            }
            catch { }
        }
    }
/*
    private void OnDestroy()
    {
        if(socketSend != null)
        {
            if(RoundStatistics.Instance != null)
            {
                RoundStatistics.Instance.RoundEndCheck();
            }            

            Debug.LogWarning("场景结束，脑机服务器的套接字关闭");
            socketSend.Close();
        }
    }
*/
}