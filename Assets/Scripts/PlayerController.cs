using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float horizontal = 0f, vertical = 0f;

    bool jump = false;
    bool sprint = false;

    public float speed = 1f;
    public float jumpPower = 100f;

    private int count;
    public Rigidbody squishedLemon;
    public AudioSource Munch;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        
        horizontal = movementValue.Get<Vector2>().x;
        vertical = movementValue.Get<Vector2>().y;
    }

    void OnJump()
    {
        jump = true;
    }

    void OnSprint()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(horizontal * speed, 0f, vertical * speed));

        if (jump)
        {
            Debug.Log("jumped");

            rb.AddForce(new Vector3(0f, jumpPower, 0f));
            jump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);

            count++;

            SetCountText();
            Katamari();
            Munch.Play();
            Instantiate(squishedLemon, transform.position, transform.rotation);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }

    void Katamari() 
    {
        Vector3 objectScale = transform.localScale;
        transform.localScale = new Vector3(objectScale.x + 1, objectScale.y + 1, objectScale.z + 1);
        rb.mass += 1;
    }
}
