using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_Dawn : MonoBehaviour
{
    public GameObject rock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rock.GetComponent<FixedJoint2D>().enabled = false;
        }
    }
}
