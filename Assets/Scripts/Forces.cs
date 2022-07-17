using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem boom;
    [SerializeField] GameObject[] pigs;
    [SerializeField] int mass;
    [SerializeField] float ShootFroce;
    [SerializeField] float gravity;
    [SerializeField] float traction;
    Vector3 vecZero = Vector3.zero;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pigs[0] = GameObject.FindGameObjectWithTag("Pig");
        pigs[1] = GameObject.FindGameObjectWithTag("Pig 2");
        pigs[2] = GameObject.FindGameObjectWithTag("Pig 3");
    }
    void Update()
    {
        vecZero = Vector3.zero;
        PullDownForce();
    }

    void PullDownForce()
    {

        float yAngle = player.transform.rotation.y;
        float xAngle = player.transform.rotation.x;
        vecZero.y += yAngle;
        vecZero.x += xAngle;
        vecZero.z += 10;

        if (!Input.GetMouseButton(0))
        {
            if (transform.position.y > 0.7) // gravity
            {
                vecZero.y -= gravity;
            }
            if (transform.position.y <= 1) // traction
            {
                vecZero.z -= traction;
            }
            if (transform.position.z <= 0.5 && transform.position.z >= -0.5 && transform.position.y < 2.5 && transform.position.y > 0.5 && transform.position.x <= 13 && transform.position.x > 10)
            {
                Destroy(gameObject);
                print("HIT");
                pigs[0].gameObject.SetActive(false);
            }
            if (transform.position.z <= 8.5 && transform.position.z >= 6.5 && transform.position.y < 2.5 && transform.position.y > 0.5 && transform.position.x <= 13 && transform.position.x > 10)
            {
                Destroy(gameObject);
                print("HIT");
                pigs[1].gameObject.SetActive(false);
            }
            if (transform.position.z <= -6.5 && transform.position.z >= -8.5 && transform.position.y < 2.5 && transform.position.y > 0.5 && transform.position.x <= 13 && transform.position.x > 10)
            {
                Destroy(gameObject);
                print("HIT");
                pigs[2].gameObject.SetActive(false);
            }
            transform.parent = null;
            transform.Translate(vecZero * ShootFroce * Time.deltaTime / mass);
            Boundaries();
        }
    } // add all forces to the ball

    void Boundaries() // if ball goes out of map destroy it
    {
        if (transform.position.z > 15 || transform.position.z < -15)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -15 || transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
