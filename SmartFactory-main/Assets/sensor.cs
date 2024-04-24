using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class sensor : MonoBehaviour
{
    public bool istouch = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            print(other.gameObject.name + "Á¢±Ù Áß");
            
        }
    }

}