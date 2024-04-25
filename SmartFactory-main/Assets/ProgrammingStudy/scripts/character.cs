using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ű �Է��� ������ Move �Լ��� ȣ���Ѵ�. 
// Ư�� ������ ���� ���� Death �ִϸ��̼��� �����Ų��. 


public class Me : MonoBehaviour
{

    public float speed = 3;
    public float runSpeed = 5;
    Animator anim;
    float currenTime = 0;
    float blendingDuration = 2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // �ɽ�: ������ �̸� ����

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            float nowSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currenTime += Time.deltaTime;
                if (currenTime >= blendingDuration)
                {
                    currenTime = blendingDuration;
                }
                nowSpeed = runSpeed;

                anim.SetInteger("Status", 2);
                anim.SetFloat("Blend", currenTime / blendingDuration);
            }
            else
            {

                currenTime = 0;

                nowSpeed = speed;

                anim.SetInteger("Status", 1);
            }
            Vector3 direction = new Vector3(h, 0, v);
            transform.position += direction * Time.deltaTime * speed;




        }
        else
        {
            anim.SetInteger("Status", 0);
        }

    }
}