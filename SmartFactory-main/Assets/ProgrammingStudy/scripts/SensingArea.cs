using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SensingArea : MonoBehaviour
{
    Transform transform;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public BoxCollider boxCollider;
    public TMP_Text boxCountTxt;
    public TMP_Text sphereCountTxt;
    int boxCount;
    int sphereCount;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        boxCountTxt.text = $"{boxCount}EA";
        sphereCountTxt.text = $"{sphereCount}EA";
    }

    
    private void OnTriggerEnter(Collider other)
    {
        print("In: "+ other.gameObject.name);  

        if(other.gameObject.name.Contains("Box"))
            boxCount++;

        if(other.gameObject.name.Contains("Sphere"))
            sphereCount++;

        boxCountTxt.text = boxCount.ToString();
        sphereCountTxt.text = sphereCount.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        print("���� �۵� ��");
    }

    private void OnTriggerExit(Collider other)
    {
        print("Out:" + other.gameObject.name);
    }
}
