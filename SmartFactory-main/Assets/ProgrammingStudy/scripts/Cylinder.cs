using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public string plcDeviceForwardAddress;
    public string plcDeviceBackwardAddress;
    public int plcForwardValue;            // 0 or 1 plcValue�� 1�϶� StartCoRoutine 
    public int plcBackwardValue;            // 0 or 1 plcValue�� 1�϶� StartCoRoutine 
    public Transform cylinderRod;   //�Ǹ��� ��ü�� ��ġ�� �ƴ� �Ǹ����ε��� ��ġ�� �ٲ��ֱ� ����.
    public float maxRange;
    public float minRange;
    public float time;
    public float currentTime;
    bool isCylinderMoving = false;

    private void Update()
    {
        if (plcForwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
        if (plcBackwardValue == 1 && isCylinderMoving == false)
            StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }

    //minRange���� maxRange�� �̵��ϴ� �Լ� 
    IEnumerator CoMoveCylinder(float minRange, float maxRange, float time)
    {
        isCylinderMoving = true;
        Vector3 originPos = new Vector3(cylinderRod.localPosition.x, minRange, cylinderRod.localPosition.z); //���� ��ġ �޾ƿ�
        Vector3 targetPos = new Vector3(cylinderRod.localPosition.x, maxRange, cylinderRod.localPosition.z); //���� ��ġ �޾ƿ�
        
        // time���� pistonRod�� originPos���� targetPos�� �̵�
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > time) // ���� �ð��� ���� ������ time ���� Ŀ���� 
            {
                currentTime = 0; // ���� �ð� �ʱ�ȭ
                break;
            }
            Vector3 newPos = Vector3.Lerp(originPos, targetPos, currentTime / time); //newPos�� originPos���� targetPos�� time ���� �̵��ϴ� �� ����.  

            cylinderRod.localPosition = newPos;

            yield return new WaitForEndOfFrame();
        }
        isCylinderMoving = false;

    }

    public void OnForwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(minRange, maxRange, time));
    }

    public void OnBackwardBtnClkEvent()
    {
        StartCoroutine(CoMoveCylinder(maxRange, minRange, time));
    }


}