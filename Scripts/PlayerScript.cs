using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int moveSpeed = 7;
    private Vector3 movement;
    private int score = 0;
    public Text scoreText;

    // Throwing Fish
    public Transform throwPoint;
    public GameObject fishPrefab;
    private float throwForce = 6.0f;

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
        // throw fish
        if (Input.GetButtonDown("Jump"))
        {
            ThrowFish();
        }
    }

    void ThrowFish()
    {
        GameObject fish = Instantiate(fishPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D rigidTemp = fish.GetComponent<Rigidbody2D>();
        rigidTemp.AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }

    public void ScorePoint(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }
}
















