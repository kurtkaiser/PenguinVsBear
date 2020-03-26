using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
    }

    private void Update()
    {
        if (transform.position.y > 7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<EnemyScript>().health--;
            collision.gameObject.GetComponent<EnemyScript>().ChangeSprite();
        }
    }
}
