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
        // 1. PosA ���� PosB ���� �̵�
        // 2. �ݼ��̶��,���� �Ǹ��� n�� �� On
        // 3. �׷��� �ʴٸ� Pos C���� �̵�

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
