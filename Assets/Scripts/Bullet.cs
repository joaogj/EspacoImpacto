using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Player player;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, speed);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "MainCamera")
        {
            // Debug.Log("colidiu");
            Destroy(gameObject);
            // TO-DO: Adicionar restante do lifecicle
        }
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(gameObject.tag != "Enemy")
    //     {
    //         if(col.tag == "Asteroid" || col.tag == "Enemy")
    //         {
    //             Destroy(gameObject);
    //             Destroy(col.gameObject);
    //         }
    //     }
    // }
}
