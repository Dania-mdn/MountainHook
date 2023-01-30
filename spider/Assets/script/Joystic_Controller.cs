using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystic_Controller : MonoBehaviour
{
    public Main_Camera Main_Camera;
    public GameObject Tragectory;
     
    public traegectori_Renderer traegectori_Renderer;

    public GameObject touch_marker;

    Vector3 target_vector;

    public Right right;

    bool IsFire = false;

    void Start()
    {
        touch_marker.transform.position = transform.position;
    }
    void Update()
    {
        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
        {
            Tragectory.SetActive(true);

            Vector3 touch_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target_vector = touch_pos - transform.position;
            if (target_vector.magnitude > 2.2f)
            {
                touch_marker.transform.position = transform.position + (touch_pos - transform.position).normalized * 2.2f;
                Destroy(right.bull);
                right.target_move = (touch_pos - transform.position).normalized * 2.2f;

                traegectori_Renderer.ShowTrajectory(right.firePoint.transform.position, (touch_pos - transform.position).normalized * 2.2f);
                Main_Camera.Origin = (touch_pos - transform.position).normalized * 2;
                Main_Camera.Distance = Vector3.Distance(touch_pos, transform.position);
                IsFire = true;
                Time.timeScale = 0.15f;
            }
            else
            {
                if (target_vector.magnitude < 0.3f)
                {
                    Destroy(right.bull);
                    Tragectory.SetActive(false);
                    touch_marker.transform.position = transform.position;
                    IsFire = false;
                }
                else
                {
                    touch_marker.transform.position = touch_pos;
                    Destroy(right.bull);
                    right.target_move = target_vector;
                    traegectori_Renderer.ShowTrajectory(right.firePoint.transform.position, target_vector);
                    Main_Camera.Origin = (touch_pos - transform.position).normalized * 2;
                    Main_Camera.Distance = Vector3.Distance(touch_pos, transform.position);
                    IsFire = true;
                }
                Time.timeScale = 0.15f;
            }
        }
    }
    public void ole()
    {
        Time.timeScale = 1;
        touch_marker.transform.position = transform.position;
        if (IsFire)
        {
            right.shoot();
            IsFire = false;
            Tragectory.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
