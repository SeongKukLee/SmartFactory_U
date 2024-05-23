using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using ActUtlType64Lib;
using System;
public delegate void ClientDele(int data);
public class Server
{
    Thread thread;
    ClientDele dele;
    ActUtlType64 mxComponent;
    public Server() 
    {
        thread = new Thread(() => Run());

        mxComponent = new ActUtlType64();
        mxComponent.ActLogicalStationNumber = 1;
    }

    // 3. �������� ������ �ް�, �۾��� ����
    public void Request(ClientDele dele)
    {
        this.dele = dele;

        thread.Start();
    }

    // 4. �۾� �� Client���� ClientDele�� ���� ������ ����
    void Run()
    {
        Thread.Sleep(3000); // �۾�

        Response();
    }

    void Response()
    {
        int deviceValue = 0;
        int ret = mxComponent.GetDevice("D0", out deviceValue);

        dele(deviceValue); // 4-1. Client�� Response �޼��� ����
    }

    public string ConnectPLC()
    {
        int ret = mxComponent.Open();
        if (ret != 0)
        {
            return ret.ToString("X");
        }
        else
            return DateTime.Now + " : PLC is connected";
    }

    public string DisconnectPLC()
    {
        int ret = mxComponent.Close();
        if (ret != 0)
        {
            return DateTime.Now + ":" + ret.ToString("X");
        }
        else
            return DateTime.Now + " : PLC is disconnected";
    }
}

