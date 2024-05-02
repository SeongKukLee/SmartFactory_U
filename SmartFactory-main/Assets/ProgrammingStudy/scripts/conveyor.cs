using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour 
{ 
    public float speed = 3;
    public float resetTime = 10;
    public float currentTime = 0;
    public GameObject pushObj;
    Vector3 pushObjOriginPos;
    public AudioClip clip;

    public void Start()
    {
        AudioManager.instance.PlayAudioClip(clip);

    }
    public void TurnOnConveyor()
    {
        pushObjOriginPos = pushObj.transform.localPosition;
        pushObj.SetActive(true);

        StartCoroutine(CoMovePushObject());
    }

    IEnumerator CoMovePushObject()
    {
        while (true)
        {
            currentTime += Time.deltaTime;
            
            if (currentTime > resetTime)
            {
                currentTime = 0;
                pushObj.transform.localPosition = pushObjOriginPos;
                // pushObj.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                break;
            }

            pushObj.transform.position += (-transform.forward) * Time.deltaTime * speed;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}