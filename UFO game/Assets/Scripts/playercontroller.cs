using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour { 

    public float speed;
    public Text counttext;
    public Text wintext;

    private Rigidbody2D rb2d;
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        wintext.text = "";
        setcounttext ();

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pickup"))
        { 
        
        other.gameObject.SetActive(false);

            count = count + 1;
            setcounttext();
        }
    }

    void setcounttext()
    {
        counttext.text = "count : " + count.ToString();

        if(count >= 12)
        {
            wintext.text = "You Win!";
        }
    }
}
