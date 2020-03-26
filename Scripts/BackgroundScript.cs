using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    public GameObject bearPrefab;
    public Text gameOverText;

    void Start()
    {
       // Random.Range(0, System.DateTime.Now.Millisecond);
        AddBear();
        AddBear();
    }

    public void AddBear()
    {
        Instantiate(bearPrefab, new Vector3(Random.Range(-7, 7),
            Random.Range(3, 7), 0), Quaternion.identity);
    }

    public void GameOver()
    {
        GameObject.Find("LoseImage").GetComponent<Renderer>().enabled = true;
        GameObject.Find("GameOverBackground").GetComponent<Renderer>().enabled = true;
        gameOverText.enabled = true;
    }
}
