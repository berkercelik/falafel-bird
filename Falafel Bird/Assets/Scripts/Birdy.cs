using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Birdy : MonoBehaviour
{
    public float velocity = 1f;
    public Rigidbody2D rb2D;

    public bool isDead;

    public GameManager managerGame;

    public GameObject DeathScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>(); //bu üstteki public rigidbody yerine olabilir

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //tıklama
        if (Input.GetMouseButtonDown(0))
        {   
            //uçurma
            rb2D.velocity = Vector2.up * velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ScoreArea")
        {
            managerGame.UpdateScore();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
        }
    }
}
