using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ð��� ����� Ư�� ������ �����Ѵ�.

public class Timer : MonoBehaviour
{
    public float currentTime = 0;
    bool isFunction1Active = false;

    private void Start()
    {
        // StartCoroutine(CoExecuteSequnce());
        StartCoroutine("CoExecuteSequnce");
    }

    // Coroutine �Լ�: �������� �۾��� �Բ� �����ϱ����� ����ϴ� C#�� ���
    IEnumerator CoExecuteSequnce()
    {
        yield return new WaitForSeconds(0.5f); // thread.sleep(2000)�� ���� 2�� ����

        CheckTime();

        yield return new WaitForSeconds(0.5f);

        CheckTime();

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        //if(currentTime > 2)
        //{
        //    CheckTime();
        //}
    }

    private void CheckTime()
    {
        //print("��� �ð�: " + currentTime); ;
    }
}
