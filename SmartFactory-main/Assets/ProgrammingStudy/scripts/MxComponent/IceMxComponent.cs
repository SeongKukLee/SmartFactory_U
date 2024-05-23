using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActUtlType64Lib; // MX Component v5 Library ���


public class IceMxComponent : MonoBehaviour
{
    public static IceMxComponent instance;
    enum Connection
    {
        Connected,
        Disconnected,
    }
    Connection connection = Connection.Disconnected;
    ActUtlType64 mxComponent;
    public Cylinder cylinderA;
    public Cylinder cylinderB;
    public Cylinder cylinderC;
    public grabcylinder grab;
    public IceCreamSensor sensorA;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mxComponent = new ActUtlType64(); // �ʱ�ȭ
        mxComponent.ActLogicalStationNumber = 1; // PLC �� ������ ���� �ѹ� 1.
        StartCoroutine(GetDevices());
    }

    private void Update()
    {

    }
    IEnumerator GetDevices()
    {
        while (true)
        {
            if (connection == Connection.Connected) //������ �Ǿ����� �� GetDevice�� �����͸� �޾ƿ��ڴ�. 
            {
                cylinderB.plcForwardValue = GetDevice(cylinderB.plcDeviceForwardAddress); // Y0�� ���� �ҷ��´�. 
                cylinderB.plcBackwardValue = GetDevice(cylinderB.plcDeviceBackwardAddress); // Y1�� ���� �ҷ��´�. 
                cylinderA.plcForwardValue = GetDevice(cylinderA.plcDeviceForwardAddress); // Y2�� ���� �ҷ��´�. 
                cylinderA.plcBackwardValue = GetDevice(cylinderA.plcDeviceBackwardAddress); // Y3�� ���� �ҷ��´�. 
                cylinderC.plcForwardValue = GetDevice(cylinderC.plcDeviceForwardAddress); // Y4�� ���� �ҷ��´�. 
                cylinderC.plcBackwardValue = GetDevice(cylinderC.plcDeviceBackwardAddress); // Y5�� ���� �ҷ��´�
                grab.plcGrabValue = GetDevice(grab.plcDeviceGrabAddress); //y10

                
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    // PC �����ϱ�
    public void OnConnectPLCBtnClkEvent()
    {
        if (connection == Connection.Disconnected)
        {
            int returnValue = mxComponent.Open();
            if (returnValue == 0)
            {
                print("���ῡ �����Ͽ����ϴ�.");
                connection = Connection.Connected;
            }
            else
            {
                print("���ῡ �����߽��ϴ�. returnValue: 0x" + returnValue.ToString("X")); // 16������ ����
            }
        }
        else
        {
            print("���� �����Դϴ�.");
        }
    }
    // PC ���� �����ϱ�
    public void OnDisconnectPLCBtnClkEvent()
    {
        if (connection == Connection.Connected)
        {
            int returnValue = mxComponent.Close();
            if (returnValue == 0)
            {
                print("���� �����Ǿ����ϴ�.");
                connection = Connection.Disconnected;
            }
            else
            {
                print("���� ������ �����߽��ϴ�. returnValue: 0x" + returnValue.ToString("X")); // 16������ ����
            }
        }
        else
        {
            print("���� ���� �����Դϴ�.");
        }
    }

    // �����͸� ������
    public bool SetDevice(string device, int data)
    {
        if (connection == Connection.Connected)
        {
            int returnValue = mxComponent.SetDevice(device, data);

            if (returnValue != 0)
            {
                print(returnValue.ToString("X"));
                return false;
            }
            return true;
        }
        else
            return false;
    }
    // �����͸� �ޱ� 
    public int GetDevice(string device)
    {
        if (connection == Connection.Connected)
        {
            int data = 0;
            int returnValue = mxComponent.GetDevice(device, out data);

            if (returnValue != 0)
                print(returnValue.ToString("X"));

            return data;
        }
        else
            return 0;
    }
}
