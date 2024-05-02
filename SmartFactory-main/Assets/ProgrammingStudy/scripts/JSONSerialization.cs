using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class DeviceInfo
{
    public string name;             // ����Ǹ���
    public string serialNumber;     // �Ǹ���A �Ǹ���B ...
    public int operationTime;       // Play ��ư ���� ���� �����ð�
    public int operationCount;      // �Ǹ��� ����, ���� Ƚ��
    public string freeWarrenty;     // �ϵ���� ���� �����Ⱓ

    public DeviceInfo(string name, string serialNumber, int operationTime, int operationCount, string paidWarrenty)
    {
        this.name = name; 
        this.serialNumber = serialNumber; 
        this.operationTime = operationTime; 
        this.operationCount = operationCount; 
        this.freeWarrenty = freeWarrenty; 
    }
}

public class JSONSerialization : MonoBehaviour
{
    public static JSONSerialization instance;
    public List<DeviceInfo> devices = new List<DeviceInfo>();
    // Object(Class) -> JSON
    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age) //������ 
        {
            this.name = name;
            this.age = age;
        }
    }




    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // ��ư�� ������, ��� device�� ������ �����Ѵ�. 

    // Start is called before the first frame update
    void Start()
    {
        /*
        // ���� �����͸� �����ϴ� ���
        DeviceInfo info = new DeviceInfo("�̼���", "123456", 55555, 5555, "2024.05.30");

        string json = JsonUtility.ToJson(info); //����ȭ (serialization)
        print(json);

        FileStream fs = new FileStream("file.json", FileMode.Create); // ������ ����, �ݴ� �⺻���� ��,��� ���
        StreamWriter sw = new StreamWriter(fs);                       // ���� ������ ������ ����, ���ڵ� ó��
        sw.Write(json);
        sw.Close();
        fs.Close();
        */
        // �������� �����͸� �����ϴ� ���
        DeviceInfo info1 = new DeviceInfo("���ް�������", "SensorA", 55555, 5555, "2024.05.30");
        DeviceInfo info2 = new DeviceInfo("���޽Ǹ���", "CylinderA", 55555, 5555, "2024.05.30");
        DeviceInfo info3 = new DeviceInfo("�����Ǹ���", "CylinderB", 55555, 5555, "2024.05.30");
        DeviceInfo info4 = new DeviceInfo("����Ǹ���", "CylinderC", 55555, 5555, "2024.05.30");
        DeviceInfo info5 = new DeviceInfo("�����̾�", "ConveyorA", 55555, 5555, "2024.05.30");
        DeviceInfo info6 = new DeviceInfo("�ݼӰ�������", "SensorB", 55555, 5555, "2024.05.30");
        DeviceInfo info7 = new DeviceInfo("����Ǹ���", "CylinderD", 55555, 5555, "2024.05.30");
        
        List<DeviceInfo> devices = new List<DeviceInfo>();
        devices.Add(info1);
        devices.Add(info2);
        devices.Add(info3);
        devices.Add(info4);
        devices.Add(info5);

        /*
        string json2 = JsonConvert.SerializeObject(devices);
        print(json2);

        fs = new FileStream("Assets/file2.json", FileMode.Create);     
        sw = new StreamWriter(fs);
        sw.Write(json2);
        sw.Close();
        fs.Close();
        
        // DeviceInfo ��� �����̳� Ŭ������ ����� �˰� ���� ��쿡 ���
        List<DeviceInfo> newdevices = new List<DeviceInfo>();
        newdevices = JsonConvert.DeserializeObject<List<DeviceInfo>>(json2);
        DeviceInfo deviceFound = newdevices.Find(x => x.name == "�̼���3");
        print(deviceFound.freeWarrenty);
        
        Person person = new Person("�̼���", 19);// Person �ν��Ͻ�ȭ 

        // ��ü -> JSON ��ȯ
        string json = JsonUtility.ToJson(person);
        print(json);

        JsonUtility.FromJson<Person>(json); //json ������ Person���� ��ȯ

        Person person2 = JsonUtility.FromJson<Person>(json);
        print($"{person2.name} {person2.age}");
        */


        //JsonUtility.FromJson(json)  JSON ������ Object�� ����ϱ� ����  
        //


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FileStream fs = new FileStream("Assets/file.json", FileMode.Open); 
            StreamReader sr = new StreamReader(fs);                       
            string json = sr.ReadToEnd();
            print(json);
            sr.Close();
            fs.Close();
        }
    }


}