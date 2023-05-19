using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle; 
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public obstaclespawner obstaclespawner;
    [SerializeField] private AudioSource swim,hit,point,catdeath;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
     // _rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Debug.Log("Swim audio clip: " + swim.clip);
        Debug.Log("Hit audio clip: " + hit.clip);
        Debug.Log("Point audio clip: " + point.clip);
        Debug.Log("CatDeath audio clip: " + catdeath.clip);
        
    }

    // Update is called once per frame
    void Update()
    { 
        FishSwim();
    }
    private void FixedUpdate()

    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
    {
        swim.Play();
        if (GameManager.gameStarted == false)
        {
            _rb.gravityScale = 4f;
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            obstaclespawner.InstantiateObstacle();
            gameManager.GameHasStarted();

        }
        else
        {
             _rb.velocity = Vector2.zero;
             _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
       
    }
    }
    
     void FishRotation()
    {
        if (_rb.velocity.y > 0)
     {
        if (angle <= maxAngle)
        {
            angle = angle + 4;
        }
     }
    else if (_rb.velocity.y < -1.2)
     {
        if (angle > minAngle)
        {
            angle = angle - 2;
        }
        
     }
     if (touchedGround == false)
     {
        transform.rotation = Quaternion.Euler(0, 0, angle);
     }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("obstacle"))

        {
            //Debug.Log("Scored!..");
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("column") && GameManager.gameOver == false)    
        {
            // game over
            FishDieEffect();
            gameManager.GameOver();
        }
    }

    void FishDieEffect()
    {
        catdeath.Play();
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (GameManager.gameOver == false)
            {
                // game over
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                // game over (fish)
                GameOver();
            }
        }
    }


    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
    

