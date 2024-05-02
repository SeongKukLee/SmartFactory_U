using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static JSONSerialization;

public class Piston : MonoBehaviour
{
    public Transform pistonRod;
    public Transform lampForward;
    public Transform lampBackward;
    public Image forwardButtonImg;
    public Image backwardButtonImg;
    public float minRange;
    public float maxRange;
    float elapsedTime = 0;
    bool isForward = true;
    public float runTime = 2;
    Vector3 minPos;
    Vector3 maxPos;
    public MetalSensor sensor;
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        DeviceInfo info = new DeviceInfo("�̼���", "123456", 55555, 5555, "2024.05.30");
        JSONSerialization.instance.devices.Add(info);

        //AudioManager.instance.PlayAudioClip(clip);
        SetActiveLampDirection(!isForward, true);

        minPos = new Vector3(pistonRod.transform.localPosition.x, minRange, pistonRod.transform.localPosition.z);
        maxPos = new Vector3(pistonRod.transform.localPosition.x, maxRange, pistonRod.transform.localPosition.z);
    }

    public void MovePistonRod(Vector3 startPos, Vector3 endPos, float _elapsedTime, float _runTime)
    {
        Vector3 newPos = Vector3.Lerp(startPos, endPos, _elapsedTime / _runTime); // t���� 0(minPos) ~ 1(maxPos) �� ��ȭ
        pistonRod.transform.localPosition = newPos;
    }

    public void OnDischargeObjectBtnEvent()
    {
        print("�۵�!");
        if (sensor != null && sensor.isMetalObject)
        {
            print("���� �Ϸ�");
            OnCylinderButtonClickEvent(true);
        }
    }

    // PistonRod�� Min, Max ����
    // ����: LocalTransform.position.y�� -0.3 ~ 1.75 ���� �̵�
    public void OnCylinderButtonClickEvent(bool direction)
    {
        StartCoroutine(CoMove(direction));
    }

    IEnumerator CoMove(bool direction)
    {
        SetActiveLampDirection(direction, true);
        SetButtonActive(false);

        float elapsedTime = 0;

        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime;

            if (direction == isForward)
            {
                print(name + " ������...");

                forwardButtonImg.color = Color.green;

                MovePistonRod(minPos, maxPos, elapsedTime, runTime);
            }
            else
            {
                print(name + " ������...");

                backwardButtonImg.color = Color.green;

                MovePistonRod(maxPos, minPos, elapsedTime, runTime);
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

        SetButtonActive(true);
    }

    void SetActiveLampDirection(bool direction, bool isActive)
    {
        if (isActive)
        {
            if (direction != isForward)
            {
                lampForward.GetComponent<MeshRenderer>().material.color = Color.green;
                lampBackward.GetComponent<MeshRenderer>().material.color = Color.white;

            }
            else
            {
                lampForward.GetComponent<MeshRenderer>().material.color = Color.white;
                lampBackward.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }

        if (direction == isForward)
        {
            forwardButtonImg.color = Color.green;
            backwardButtonImg.color = Color.white;
        }
        else
        {
            forwardButtonImg.color = Color.white;
            backwardButtonImg.color = Color.green;
        }
    }

    void SetButtonActive(bool isActive)
    {
        forwardButtonImg.GetComponent<Button>().interactable = isActive;
        backwardButtonImg.GetComponent<Button>().interactable = isActive;
    }
}