using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public static GameManager Instance;
    public StateMachine stateMachine;
    public float timeToSetBallFree = 1f;

    [Header ("Menus")]
    public GameObject uiMainMenu;

    void Awake()
    {
        Instance = this;
    }




    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }


    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

   

    public void StartGame()
    {

        ballBase.CanMove(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowEndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        Debug.Log("Entered Main Menu");
        Time.timeScale = 0;
        uiMainMenu.SetActive(true);
        
    }
}
