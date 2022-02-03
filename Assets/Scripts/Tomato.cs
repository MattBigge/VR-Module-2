using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Tomato : MonoBehaviour
{
    private int count;
    private int countOfTomatoes;
    private int missedThrows;
    private int score;

    private Rigidbody rb;
    public AudioSource splatSound;
    public AudioSource collectTone;
    public AudioSource congratsSound;

    public TextMeshPro scoreText;
    public TextMeshPro missedText;
    public TextMeshPro ammoText;
    public GameObject splattedTomato;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countOfTomatoes = 10;
        missedThrows = 0;
        score = 0;
        SetAmmoText();
        SetMissedText();
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when tomato collides with wall or collectible
    void OnTriggerEnter(Collider other)
    {
        //if tomato collides with colectible
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetScoreText();
            collectTone.Play();
            this.gameObject.SetActive(false);

            countOfTomatoes--;
            SetAmmoText();
        }
        //if tomato collides with back wall
        if (other.gameObject.CompareTag("BackWall"))
        {
            missedThrows++;
            SetMissedText();
            splatSound.Play();

            countOfTomatoes--;
            SetAmmoText();
            //retrieve better location for splat graphic
            //Vector3 hitlocation = new Vector3(transform.x, objectPosition.y, transform.z);
            Instantiate(splattedTomato, transform.position, transform.rotation);
        }
    }

    void SetScoreText()
    {
        score = count * 100;
        scoreText.text = "Score: " + score.ToString();
        if (score >= 500)
        {
            scoreText.text = "You Win!";
            missedText.text = "";
            ammoText.text = "";
            congratsSound.Play();
        }
    }

    void SetMissedText()
    {
        missedText.text = "Misses: " + missedThrows.ToString();
    }

    void SetAmmoText()
    {
        ammoText.text = "Ammo: " + countOfTomatoes;
    }
}
