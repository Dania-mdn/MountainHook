using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joistyc : MonoBehaviour
{
    public GameObject joistic_left;
    public GameObject joistic_Right;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        joistic_Right.SetActive(false);
        joistic_left.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.Play();
            if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.91f || Camera.main.ScreenToViewportPoint(Input.mousePosition).y < 0.84f)
            {
                if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
                {
                    joistic_Right.SetActive(true);
                    joistic_Right.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5f)
                {
                    joistic_left.SetActive(true);
                    joistic_left.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            audioSource.Stop();
            joistic_Right.GetComponent<Joystic_Controller>().ole();
            joistic_left.GetComponent<Joistyc_Left>().ole();
        }
    }
}
