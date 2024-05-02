using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    public float speed = 3;
    public GameObject pushObj;
    public Transform posA;
    public Transform posB;
    public Transform posC;
    // Start is called before the first frame update
    
    public void TurnOnConveyor()
    {
        pushObj.SetActive(true);

        StartCoroutine(CoMovePushObject());
        // 1. PosA 에서 PosB 까지 이동
        // 2. 금속이라면,배출 실린더 n초 후 On
        // 3. 그렇지 않다면 Pos C까지 이동

    }

    IEnumerator CoMovePushObject()
    {
        while (true)
        {
            pushObj.transform.position += (-transform.forward) * Time.deltaTime * speed;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
