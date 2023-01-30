using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int i;
    AudioSource audio;
    Animator anim;
    Collider2D Collider;
    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        PlayerPrefs.DeleteKey("Coin_lvl");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Collider.enabled = false;
            anim.SetBool("IsCoin", true);
            audio.Play();
            if (PlayerPrefs.HasKey("Coin_lvl"))
            {
                PlayerPrefs.SetInt("Coin_lvl", PlayerPrefs.GetInt("Coin_lvl") + i);
            }
            else
            {
                PlayerPrefs.SetInt("Coin_lvl", i);
            }
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
