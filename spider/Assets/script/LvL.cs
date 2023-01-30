using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvL : MonoBehaviour
{
    public GameObject[] lvl;
    public GameObject load;
    public GameObject GO;
    private void Start()
    {
        if (PlayerPrefs.HasKey("LvL"))
        {
            for(int i = 0; i < PlayerPrefs.GetInt("LvL"); i++)
            {
                if (lvl[i].activeSelf == false)
                {
                    lvl[i].SetActive(true);
                }
            }
        }
    }
    public void Lvl()
    {
        if (PlayerPrefs.HasKey("LvL"))
        {
            StartCoroutine(Coroutine(PlayerPrefs.GetInt("LvL")));
        }
        else
        {
            StartCoroutine(Coroutine(1));
        }
    }
    public void Lvl_number(int number)
    {
        StartCoroutine(Coroutine(number));
    }
    IEnumerator Coroutine(int number)
    {
        load.SetActive(true);
        GO.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(number);
    }
    public void Delete_Key()
    {
        PlayerPrefs.DeleteKey("LvL");
        PlayerPrefs.DeleteKey("tich");
    }
    public void Delete_Coin()
    {
        PlayerPrefs.DeleteKey("Coin");
        PlayerPrefs.DeleteKey("ads"); 
        PlayerPrefs.DeleteKey("IMG_Locc" + 0);
        PlayerPrefs.DeleteKey("IMG_Locc" + 1);
        PlayerPrefs.DeleteKey("IMG_Locc" + 2);
        PlayerPrefs.DeleteKey("IMG_Locc" + 3);
        PlayerPrefs.DeleteKey("IMG_Locc" + 4);
        PlayerPrefs.DeleteKey("Sprite_Player");
    }
    public void Add_Key()
    {
        PlayerPrefs.SetInt("LvL", lvl.Length);
    }
}
