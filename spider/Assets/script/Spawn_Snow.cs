using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Snow : MonoBehaviour
{
    public GameObject star;

    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(spawn_1());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, 0));
            Instantiate(star, pos, Quaternion.Euler(0, 0, Random.Range(170, 250f)));
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator spawn_1()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));
            Instantiate(star, pos, Quaternion.Euler(0, 0, Random.Range(170, 250f)));
            yield return new WaitForSeconds(0.7f);
        }
    }
}
