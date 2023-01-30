using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olaf_Children : MonoBehaviour
{
    FixedJoint2D Fixed;
    private void Start()
    {
        Fixed = GetComponent<FixedJoint2D>();
    }
    void Update()
    {
        if(Fixed.connectedBody == null)
        {
            Invoke("Destroy", 3);
        }
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
