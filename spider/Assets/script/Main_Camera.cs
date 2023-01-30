using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public GameObject Player;
    public GameObject Finish;
    public Vector3 Origin;
    public float speed = 0.5f;
    public float Distance;
    public GameObject lvlSound;
    GameObject new_lvlSound;
    private void Start()
    {
        this.transform.position = Finish.transform.position;
        Camera.main.orthographicSize = 5;
    }
    void Update()
    {
        if (GameObject.Find("lvlSound") == null && GameObject.Find("lvlSound(Clone)") == null)
        {
            new_lvlSound = Instantiate(lvlSound);
        }
        else
        {
            new_lvlSound = GameObject.Find("lvlSound(Clone)");
        }
        if (Player.GetComponent<Rigidbody2D>().velocity.magnitude > 4 && Camera.main.orthographicSize < 5.5f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 0.8f * Time.deltaTime;
        }
        else if(Player.GetComponent<Rigidbody2D>().velocity.magnitude < 4 && Camera.main.orthographicSize > 4)
        {
            if (Distance > 1 && Camera.main.orthographicSize < 5.5f)
            {
                Camera.main.orthographicSize = Camera.main.orthographicSize + 2 * Time.deltaTime;
            }
            else
            {
                if(Camera.main.orthographicSize > 4.01f)
                {
                    Camera.main.orthographicSize = Camera.main.orthographicSize - 1 * Time.deltaTime;
                }
            }
        }
        if (Player.GetComponent<Rigidbody2D>().velocity.magnitude > 3)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + 0.2f, 0), (Player.transform.position - this.transform.position).magnitude * Time.deltaTime);
            Origin = new Vector3(0, 0, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x + Origin.x, Player.transform.position.y + Origin.y + 0.2f, 0), 8 * Time.deltaTime);
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + 0.2f, 0), 2 * Time.deltaTime); 
                Origin = new Vector3(0, 0, 0);
                Distance = 0;
            }
        }
    }
    public void Deledet_Sound()
    {
        Destroy(new_lvlSound);
    }
}