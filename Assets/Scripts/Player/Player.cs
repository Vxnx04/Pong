using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 15;
    public string playerName = "Player 1";
    public Image uiPlayer;
    public ChangeName getPlayerName;

    [Header("Key Setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;
    public Rigidbody2D meuRigidBody;
    public AudioSource myBGSound;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;
    public int maxPoints = 4;
    public TextMeshProUGUI winnerText;



    void Awake()
    {
        meuRigidBody = gameObject.GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    void Update()
    {
        if(Input.GetKey(keyCodeMoveUp))
        meuRigidBody.MovePosition(transform.position + transform.up * speed);

        else if (Input.GetKey(keyCodeMoveDown))
        meuRigidBody.MovePosition(transform.position + transform.up * -speed);
    }

    public void AddPoint()
    {
        myBGSound.pitch += 0.03f;
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text =  currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.ShowEndGame();
            winnerText.text = ("Winner is "+ playerName);
            HSManager.Instance.SavePlayerWin(this);
        }
    }
}
