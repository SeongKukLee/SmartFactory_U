using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

// 시작 시 Player가 뒤 방향으로 이동한다.
public class Player : MonoBehaviour
{
    public float speed = 2;
    public Transform destination;
    public float distanceLimit = 0.3f; // 20cm
    public Timer timer;
    float arrivalTime = 0;
    bool isArrived = false;
    public sensor sensor;
    

    void Start()
    {
        
    }

    void Update() // 프레임이 갱신될 때 실행되는 메서드 0.002 ~ 0.004초에 한번 씩 실행
    {

        if (!isArrived)
        {
            Vector3 direction = Vector3.back;

            // 현 위치에서부터 destination 까지의 벡터
            Vector3 dir2Dest = (destination.position - transform.position).normalized; // 방향은 같고 크기가 1인 벡터 형성
            float distance = (destination.position - transform.position).magnitude; // 거리의 크기

            if (distance > distanceLimit)
            {
                transform.position += dir2Dest * Time.deltaTime * speed;
            }
            else
            {
                isArrived = true;

                // 도착 시 알림
                arrivalTime = timer.currentTime;
                print("도착시간 : " + arrivalTime);    
            }
        }

    }
    // 충돌이 시작되었을 때 실행되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "드리블 직전");
        }
    }

    // 충돌중일때 실행되는 함수
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "드리블 중");
        }
    }

    // 충돌이 끝났을 때 실행되는 함수
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(collision.gameObject.name + "슛!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print("OnTriggerEnter");
            
        }
    }
}

