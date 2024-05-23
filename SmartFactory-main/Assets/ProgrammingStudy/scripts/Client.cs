using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Client : MonoBehaviour
{
    Server server;

    private void Start()
    {
        // 1.������ �����
        server = new Server();

        // 2. ������ ResponseData��� �޼��带 ���
        // RequestData();
    }

    void RequestData()
    {
        // 2-1. ResponseData �޼��� ��� ������ Client Dele�� ����
        ClientDele requestDele = new ClientDele(ResponseData);
        server.Request(requestDele);
    }

    void ResponseData(int data)
    {
        print(data);
    }
    public void OnConnectBtnClkEvent()
    {
        string ret = server.ConnectPLC();
        print(ret);
    }

    public void OnDisconnectBtnClkEvent()
    {
        string ret = server.DisconnectPLC();
        print(ret);
    }

    public void OnGetDataBtnClkEvent()
    {
        RequestData();
    }

    public void OnSetDataBtnClkEvent()
    {

    }
}
