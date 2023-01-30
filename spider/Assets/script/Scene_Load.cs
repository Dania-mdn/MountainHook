using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Load : MonoBehaviour
{
    public GameObject Win;
    public GameObject Joistik;
    public int Index;
    [SerializeField] InterAd AdTransition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Win.SetActive(true);
            Joistik.SetActive(false);
            Time.timeScale = 0;
            if (PlayerPrefs.HasKey("LvL"))
            {
                if (PlayerPrefs.GetInt("LvL") < Index)
                {
                    PlayerPrefs.SetInt("LvL", Index);
                }
            }
            else
            {
                PlayerPrefs.SetInt("LvL", 2);
            }
        }
    }
    public void LoadSceneMode(int ind)
    {
        SceneManager.LoadScene(ind);
        Time.timeScale = 1;
    }
    public void Next_LvL()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Index); 
        if (PlayerPrefs.HasKey("Coin_lvl"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("Coin_lvl"));
            PlayerPrefs.DeleteKey("Coin_lvl");
        }
    }
    public void Next_LvL_x_2()
    {
        AdTransition.ShowAd();
        if (PlayerPrefs.HasKey("Coin_lvl"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + (PlayerPrefs.GetInt("Coin_lvl") * 2));
            PlayerPrefs.DeleteKey("Coin_lvl");
        }
    }
}
