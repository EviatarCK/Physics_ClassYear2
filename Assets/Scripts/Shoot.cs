using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void SpawnShot()
    {

        if (Input.GetMouseButtonDown(0) && !BallIsAlive)
        {
            var rand = Random.Range(0, 11);
            Instantiate(Ball[rand], FirePoint);

        }

        if (Input.GetMouseButtonUp(0))
        {
            Invoke("DestroyTheBall", 5);
        }
    }

    void DestroyTheBall()
    {
        var _currentBall = GameObject.FindGameObjectWithTag("Ball");
        Destroy(_currentBall);
    }

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
    }
}
