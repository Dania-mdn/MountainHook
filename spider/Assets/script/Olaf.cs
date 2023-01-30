using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olaf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
