using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tich : MonoBehaviour
{
    public int i;
    public GameObject Tich; 
    public GameObject tich_defolt;
    void Start()
    {
        if (PlayerPrefs.HasKey("tich") == false)
        {
            tich_defolt.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("tich") < i)
            {
                PlayerPrefs.SetInt("tich", i);
                Tich.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
