using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간의 경과를 특정 변수에 저장한다
public class Timer : MonoBehaviour
{
    public float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // 0.003초

        print("경과 시간 : " + currentTime);
    }
}
