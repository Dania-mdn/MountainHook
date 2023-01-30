using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_anim : MonoBehaviour
{
    private float _movementSpeed;
    float i;
    public float min;
    public float max;

    void Start()
    {
        i = Random.Range(min, max);
        this.transform.localScale = new Vector3(i, i, 1);
        _movementSpeed = Random.Range(0.5f, 1f);
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        //Move star
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }
}
