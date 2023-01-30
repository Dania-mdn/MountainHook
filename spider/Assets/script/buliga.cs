using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buliga : MonoBehaviour
{
    public GameObject Buliga_point;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deaf")
        {
            this.transform.position = Buliga_point.transform.position;
        }
    }
}
