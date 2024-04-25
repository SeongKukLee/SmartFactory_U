using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform destination;
    public int status = 0;
    public float 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:
                break;
            case 1:
                Move(destination);
                break;
            case 2:

                break;
        }

    }
}

private void Move(Transform destination)
{
    Vector3 direction = (destination.position - Transform.position).normalized;
    float distanc = (destination.position - Transform.position).magnitude;
    if(distanc < range)
    {

    }
}