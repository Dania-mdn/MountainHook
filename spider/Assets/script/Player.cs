using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject respavn;
    Rigidbody2D rb;
    AudioSource audioSource;
    public AudioSource audio_Crash;
    public GameObject joistyk;
    private int tryCount;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    public GameObject parachute;
    bool isParasute;
    bool isconnect;

    [SerializeField] InterAd AdTransition;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        rb = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey("Sprite_Player"))
        {
            spriteRenderer.sprite = sprite[PlayerPrefs.GetInt("Sprite_Player")];
        }
        else
        {
            spriteRenderer.sprite = sprite[0];
        }

        if (PlayerPrefs.HasKey("tryCount"))
        {
            tryCount = PlayerPrefs.GetInt("tryCount");
        }
    }
    void Update()
    {
        //работа с парашутом
        if (PlayerPrefs.HasKey("mousDoun1") || PlayerPrefs.HasKey("mousDoun2") || isconnect == true)
        {
            isParasute = false;
        }
        else if(rb.velocity.y < -2.5f)
        {
            isParasute = true;
        }
        if(isParasute == true)
        {
            parachute.SetActive(true);
            if (rb.velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(rb.velocity.x / 1.07f, -0.5f);
            }
        }
        else
        {
            parachute.SetActive(false);
        }
        //поворот
        if (rb.velocity.x > 1)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (rb.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        if (rb.velocity.magnitude > 7)
        {
            audioSource.volume = audioSource.volume + 0.04f;
        }
        else
        {
            audioSource.volume = audioSource.volume - 0.04f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isconnect = true;
        if (collision.gameObject.tag == "Deaf" || collision.gameObject.tag == "Deaf1")
        {
            rb.freezeRotation = false;
            joistyk.SetActive(false);
            Invoke("Restart", 1);

            if (tryCount >= 3)
            {
                AdTransition.ShowAd();
                tryCount = 0;
                PlayerPrefs.SetInt("tryCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("tryCount", PlayerPrefs.GetInt("tryCount") + 1);
                tryCount++;
            }
        }
        if (collision.relativeVelocity.magnitude > 4) 
        {
            audio_Crash.Play();
            audio_Crash.volume = collision.relativeVelocity.magnitude / 30;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isconnect = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
