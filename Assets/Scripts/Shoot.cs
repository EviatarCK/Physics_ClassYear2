using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject[] Ball;
    public bool BallIsAlive;

    void Update()
    {
        SpawnShot();
        IsBallAlive();
    }

    void SpawnShot() //spawn the ball
    {

        if (Input.GetMouseButtonDown(0) && !BallIsAlive)
        {
            var rand = Random.Range(0, 5);
            Instantiate(Ball[rand], FirePoint);
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyTheBall();
        }
    }

    void DestroyTheBall()
    {
        var _currentBall = GameObject.FindGameObjectWithTag("Ball");
        Destroy(_currentBall);
    } // destroy ball

    void IsBallAlive()
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null) 
        {
            BallIsAlive = false;
        }
        else
        {
            BallIsAlive = true;
        }
    } // checks if the ball alive

}
