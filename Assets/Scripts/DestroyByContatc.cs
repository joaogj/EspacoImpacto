﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContatc : MonoBehaviour
{
    private int scoreValue = 10;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(gameObject.tag == "Bullet")
        {
            if(other.tag == "Asteroid" || other.tag == "Enemy")
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                gameController.AddScore (scoreValue);
                Debug.Log("pontuação aumenta");
            }
        }
        // Destroy(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Asteroid")
        {
            Destroy(col.gameObject);
        }
    }
}