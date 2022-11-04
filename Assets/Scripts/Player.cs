using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float turnSpeed;
    public int health;
    public int score;
    public TMP_Text scoreDisplay;
    public TMP_Text healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score: " + score;
        healthDisplay.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health--;
        healthDisplay.text = "Health: " + health;
        if (health <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void AddScore()
    {
        score++;
        scoreDisplay.text = "Score: " + score;
    }
}
