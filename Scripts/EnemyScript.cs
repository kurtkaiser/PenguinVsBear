using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float bearSpeed = -2.0f;
    private Vector3 movement;
    public int health = 2;
    private float xMove;
    private float yMove;
    public Sprite[] sprites;

    void Start()
    {
        //Random.InitState(Random.Range(0, System.DateTime.Now.Millisecond));
        xMove = Random.Range(-15, 15) * 0.05f;
        yMove = Random.Range(3, 15) * 0.08f;
    }

    // Update is called once per frame
    void Update()
    {
        //Random.Range(0, System.DateTime.Now.Millisecond);
        xMove = xMove + Random.Range(-2, 2) * 0.005f;
        movement = new Vector3(xMove, yMove, 0f);
        transform.position += movement * bearSpeed * Time.deltaTime;
        GetGameOver();
    }

    public void ChangeSprite()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerScript>().ScorePoint(3);
            GameObject.Find("Background").GetComponent<BackgroundScript>().AddBear();
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().ScorePoint(1);
            this.GetComponent<SpriteRenderer>().sprite = sprites[health];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bumper" || collision.transform.tag == "Enemy")
        {
            xMove = xMove * -1.1f;
        } 
        else if(collision.transform.name == "Player")
        {
            transform.position = new Vector3(0, -10, 0);
        }
    }

    void GetGameOver()
    {
        if(transform.position.y < -6)
        {
            GameObject player = GameObject.Find("Player");
            Destroy(this.gameObject);
            GameObject.Find("Background").GetComponent<BackgroundScript>().GameOver();
        }
    }
}
