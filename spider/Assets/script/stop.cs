using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Stop()
    {
        anim.SetBool("right", false);
        anim.SetBool("left", false);
    }
}
