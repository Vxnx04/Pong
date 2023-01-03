using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public string tagToCheck = "Ball";
    public Player player;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == tagToCheck)
        {
            CountPoint();
        }
    }


    void CountPoint()
    {
        AudioManager.Instance.Play("HitOnWall");
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
