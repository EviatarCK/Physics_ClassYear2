using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] int mass;
    [SerializeField] float ShootFroce;
    [SerializeField] float gravity;
    [SerializeField] float traction;
    Vector3 vecZero = Vector3.zero;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (transform.position.y > 1) //gravity
            {
                vecZero.y -= gravity;
            }
            if (transform.position.y <= 1) // traction
            {
                vecZero.z -= traction;
            }
            transform.parent = null;
            transform.Translate(vecZero * ShootFroce * Time.deltaTime / mass);
            Boundaries();
        }
    }

    void Boundaries()
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
