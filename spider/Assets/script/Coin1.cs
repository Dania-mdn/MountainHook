using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin1 : MonoBehaviour
{
    public TextMeshProUGUI Coin_text;
    public TextMeshProUGUI Coin_x_2;
    float i = 0;
    int y = 0;
    void Start()
    {
        Coin_text.text = (PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("Coin_lvl")).ToString();
        PlayerPrefs.DeleteKey("Coin_lvl");
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("Coin_lvl"))
        {
            if (Coin_x_2 != null)
            {
                Coin_x_2.text = PlayerPrefs.GetInt("Coin_lvl").ToString("0");
            }

            if(PlayerPrefs.GetInt("Coin") + i <= PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("Coin_lvl"))
            {
                Coin_text.text = (PlayerPrefs.GetInt("Coin") + i).ToString("0");
                i = i + 0.5f;
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("Coin_b"))
            {
                if (PlayerPrefs.GetInt("Coin") + y <= PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("Coin_b"))
                {
                    Coin_text.text = (PlayerPrefs.GetInt("Coin") + y).ToString();
                    y = y + 2;
                }
                else
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("Coin_b"));
                    PlayerPrefs.DeleteKey("Coin_b");
                    y = 0;
                }
            }
            else
            {
                Coin_text.text = PlayerPrefs.GetInt("Coin").ToString();
            }
        }
    }
}
