using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BayPlayer : MonoBehaviour
{
    public int ID;
    public int price;
    public GameObject IMG_Locc;
    public GameObject Coin;
    public GameObject background;
    public TextMeshProUGUI Coin_text;
    public AudioSource audio;
    void Start()
    {
        Coin_text.text = price.ToString();
        if (PlayerPrefs.HasKey("IMG_Locc" + ID))
        {
            if (PlayerPrefs.GetInt("IMG_Locc" + ID) == 1)
            {
                IMG_Locc.SetActive(false);
                Coin.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("background"))
        {
            if (PlayerPrefs.GetInt("background") == ID)
            {
                background.SetActive(true);
            }
            else
            {
                background.SetActive(false);
            }
        }
    }

    public void UnlocPlayer()
    {
        if(PlayerPrefs.GetInt("Coin") > price)
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - price);
            IMG_Locc.SetActive(false);
            PlayerPrefs.SetInt("IMG_Locc" + ID, 1);
            Coin.SetActive(false);
            PlayerPrefs.SetInt("background", ID);
        }
    }
    public void activate()
    {
        audio.Play();
        PlayerPrefs.SetInt("Sprite_Player", ID);
        Coin.SetActive(false);
        PlayerPrefs.SetInt("background", ID);
    }
}
