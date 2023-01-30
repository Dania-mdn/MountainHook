using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolet : MonoBehaviour
{
    public Vector3 target_move;
    public float Bulletspeed;
    Rigidbody2D rb;
    FixedJoint2D Joint2D;
    public bool Is_Connekt = false;
    public float second = 1.5f;
    AudioSource audioSource;
    CircleCollider2D circle;
    public GameObject particl;
    GameObject a;
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(target_move * Bulletspeed, ForceMode2D.Impulse);
        Joint2D = GetComponent<FixedJoint2D>();
    }
    private void Update()
    {
        if(second > 0)
        {
            second = second - Time.deltaTime;
        }
        else
        {
            if(Is_Connekt == false)
            {
                Destroy(this.gameObject);
            }
        }
        if(a != null)
        {
            Destroy(a, 2);
        }
        //rb.WakeUp();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Connect")
        {
            audioSource.Play();
            if(particl != null)
            {
                a = Instantiate(particl, this.transform.position, Quaternion.identity);
            }
            Joint2D.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Joint2D.enabled = true;
            Is_Connekt = true; 
        }
        if (collision.gameObject.tag == "Deaf")
        {
            circle.isTrigger = false;
        }
    }
}
