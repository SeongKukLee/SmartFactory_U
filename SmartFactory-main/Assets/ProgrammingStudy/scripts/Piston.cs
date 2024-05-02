using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Transform pistonRod;
    public Transform lampForward;
    public Transform lampBackward;
    public float minRange;
    public float maxRange;
    bool isForward = true;
    float elapsedTime = 0;
    public float runTime = 2;
    Vector3 minPos;
    Vector3 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        lampForward.GetComponent<MeshRenderer>().material.color = Color.green;

        minPos = new Vector3(pistonRod.transform.localPosition.x, minRange, pistonRod.transform.localPosition.z);
        maxPos = new Vector3(pistonRod.transform.localPosition.x, maxRange, pistonRod.transform.localPosition.z);
    }

    private void Update()
    {
    }

    public void MovePistonRod(Vector3 startPos, Vector3 endPos, float _elapsedTime, float _runTime)
    {
        Vector3 newPos = Vector3.Lerp(startPos, endPos, _elapsedTime / _runTime); // t���� 0(minPos) ~ 1(maxPos) �� ��ȭ
        pistonRod.transform.localPosition = newPos;
    }

    // PistonRod�� Min, Max ����
    // ����: LocalTransform.position.y�� -0.3 ~ 1.75 ���� �̵�
    public void OnCylinderButtonClickEvent(bool direction)
    {
        StartCoroutine(CoMove(direction));
    }

    IEnumerator CoMove(bool direction)
    {
        float elapsedTime = 0;

        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime;

            if (direction == isForward)
            {
                print("�� �������� ���� ��...");

                MovePistonRod(minPos, maxPos, elapsedTime, runTime);
            }
            else
            {
                MovePistonRod(maxPos, minPos, elapsedTime, runTime);
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}