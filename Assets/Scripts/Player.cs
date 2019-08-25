using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Done_Boundary 
{
    public float xMin, xMax, yMin, yMax;
}
public class Player : MonoBehaviour
{

    private float speed;
    private float nextFire;
    private int lifeCount;
    public Text life;

    public GameObject shot;
    public Transform shotSpawn;
    public float shotRate;
    public float powerTime = 5f;

    /*public Player(float speed, float nextFire, int life, int score)
    {
        this.speed = speed;
        this.nextFire = nextFire;
        this.life = life;
        this.score = score;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
        speed = 1f;
        shotRate = 0f;
        LifeUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //Touch myTouch = Input.GetTouch(0);
        Touch[] myTouches = Input.touches;
        
        for(int i = 0; i < Input.touchCount; i++)
        {
            //Do something with the touches
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if(Time.time > nextFire)
                {
                    nextFire = Time.time + shotRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
        }

        //Código para teste em desktop na unity
        if(Input.GetKeyDown(KeyCode.Space))
        {
             if(Time.time > nextFire)
             {
                nextFire = Time.time + shotRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
             }
        }
        LifeUpdate();
    } 

    //Movimentação no desktop
    void FixedUpdate() 
    {
        transform.Translate(Input.acceleration.x * 0.8f, 0, 0);

        //Código para teste em desktop na unity
         if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
        }
    }
    
    void LifeUpdate()
    {
        life.text = "Vidas: " + lifeCount.ToString();
        if(lifeCount <= 0) 
        {
            Destroy(gameObject);
            // TO-DO: Adicionar restante do lifecicle
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Asteroid" || other.tag == "Enemy")
        {
            lifeCount--;
            Destroy(other.gameObject);
        }
        
        if (other.tag == "PowerUp")
        {
            LifePowerUp();
            Destroy(other.gameObject);
            Debug.Log("colidu");
        } 
    }

    void LifePowerUp()
    {
        lifeCount++;
    }
}
