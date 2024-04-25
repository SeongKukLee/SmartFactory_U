using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class sensor2 : MonoBehaviour
{
    public bool istouch = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(other.gameObject.name + "°ø °È¾î³»±â");
            istouch = true;
        }
    }

}