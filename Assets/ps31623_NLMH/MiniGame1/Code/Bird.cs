using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    public bool isGameOver;
    public bool startGame;
    public GameObject gameController;
    public GameObject message;
    public GameObject gameOver;
    public int score;
    public Text scoreText;
    public GameObject exitButton;
    public GameObject notific;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        startGame = false;

        isGameOver = false;
        rb.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
        gameOver.GetComponent<SpriteRenderer>().enabled = false;
        exitButton.SetActive(false);
        notific.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundController.instance.PlayThisSource("wing", 5f);

                if (!startGame)
                {

                    startGame = true;
                    rb.gravityScale = 3;
                    gameController.GetComponent<PipeController>().startPipe = true;
                    message.GetComponent<SpriteRenderer>().enabled = false;
                }
                jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReloadScene();
            }
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSource("hit", 5f);
        score = 0;
        scoreText.text = score.ToString();
        GameOver();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pige"))
        {
            SoundController.instance.PlayThisSource("point", 5f);
            score += 1;
            scoreText.text = score.ToString();
        }
        if (collision.gameObject.CompareTag("gem"))
        {
            Time.timeScale = 0;
            notific.SetActive(true);
            exitButton.SetActive(true);
            Destroy(collision.gameObject);
        }
    }


    private void GameOver()
    {
        isGameOver = true;
        gameOver.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MG1" + "");
    }
}