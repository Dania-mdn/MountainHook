using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public Animator anim; 
    public GameObject Player;
    public SpringJoint2D Joint;
    public LineRenderer line;
    public Vector3 target_move;
    public GameObject firePoint;
    public GameObject boolet;
    public GameObject bull;
    public float stopping;
    public float stopping_0;
    public GameObject Joistick_right;
    Vector3 dir;
    float angle;
    public GameObject Gun;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Joint.enabled = false;
        line.enabled = false;
    }
    private void FixedUpdate()
    {
        if (bull != null)
        {
            if (bull.GetComponent<boolet>().Is_Connekt == true)
            {
                Joint.enabled = true;
                Joint.connectedBody = bull.GetComponent<Rigidbody2D>();
                if (Joint.distance > 0.5f)
                {
                    Joint.distance -= stopping;
                }
            }
        }
    }
    void Update()
    {
        if (bull != null)
        {
            PlayerPrefs.SetInt("mousDoun2", 1);
            line.enabled = true;
            line.SetPosition(0, Player.transform.position);
            line.SetPosition(1, bull.transform.position);
            dir = bull.transform.position - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            PlayerPrefs.DeleteKey("mousDoun2");
            Joint.enabled = false;
            line.enabled = false;
            if (Input.GetKey(KeyCode.Mouse0) && Joistick_right.activeSelf == true)
            {
                angle = Mathf.Atan2(target_move.y, target_move.x) * Mathf.Rad2Deg;
                Gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                angle = Mathf.Atan2(1, 1) * Mathf.Rad2Deg;
                Gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        if (transform.parent.transform.localScale.x == -0.3f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localPosition = new Vector3(-0.33f, 0.13f, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localPosition = new Vector3(0.43f, 0.13f, 0);
        }
    }
public void shoot()
    {
        audioSource.Play();
        bull = Instantiate(boolet, firePoint.transform.position, firePoint.transform.rotation);
        bull.GetComponent<boolet>().target_move = target_move;
        anim.Play("Right");
        anim.SetBool("right", true);
    }
}
