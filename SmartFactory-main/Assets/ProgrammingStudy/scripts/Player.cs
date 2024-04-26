﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 시작시 Player가 뒤 방향으로 이동한다.
public class Cylinder : MonoBehaviour
{
    public float speed = 2;
    public float distanceLimit = 0.3f;
    public float startTime = 2;
    float arrivalTime = 0;
    float currentTime;
    public Transform destination;
    public sensor sensor;
    public Timer timer;

    // 프레임이 갱신될 때 실행되는 메서드 0.002 ~ 0.004초에 한번씩 실행
    void Update()
    {
        if (sensor.isObjectDetected)
        {
            currentTime += Time.deltaTime;

            if (currentTime > startTime)
            {
                // 현 위치에서부터 destination까지의 벡터
                Vector3 dir2Dest = (destination.position - transform.position).normalized;
                float distance = (destination.position - transform.position).magnitude;

                if (distance > distanceLimit)
                {
                    transform.position += dir2Dest * Time.deltaTime * speed;
                }
                else
                {
                    sensor.isObjectDetected = false;
                    GetComponent<Rigidbody>().velocity = Vector3.zero; // 작용 반작용을 Zero

                    // 도착 시 알림
                    arrivalTime = timer.currentTime;
                    print("도착시간: " + arrivalTime);

                    currentTime = 0;
                }
            }
        }
    }

    // 충돌이 시작되었을 때 실행되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "에 충돌이 시작되었습니다.");
        }
    }

    // 충돌이 진행 중 실행되는 함수
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "에 붙어있습니다.");
        }
    }

    // 충돌이 끝났을 때 실행되는 함수
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "에 충돌이 끝났습니다.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print("OnTriggerEnter");
        }
    }
}
