using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
  public Vector3 speed = new Vector3(1,1);
  public Vector3 startSpeed;
  public string stringToCheck = "Player"; 
  private Rigidbody2D myRigidBody;
  public static BallBase Instance;

  [Header("Randomize")]
  public Vector2 randSpeedY = new Vector2 (1,3);
  public Vector2 randSpeedX = new Vector2 (1,3);

  private Vector3 _startPosition;
  public bool canMove = false;


    void Awake()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        _startPosition = myRigidBody.position;
        startSpeed = speed;
        Instance = this;
    }

    void Update()
    {
        if (!canMove) return;
        myRigidBody.MovePosition(transform.position + speed);

        if (Input.GetKey(KeyCode.R))
        GameManager.Instance.Restart();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == stringToCheck)
        {
        AudioManager.Instance.Play("HitOnPaddle");
    //    FeedbackManager.Instance.objectDo.PlayFeedbacks();
        OnPlayerCollision();
        }
        if(other.gameObject.tag == "Border")
        {
        AudioManager.Instance.Play("TopOrBottom");
        speed.y *= -1;
        }


    }
  

    void OnPlayerCollision()
    {
        
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);
        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;


        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;

    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
  }
