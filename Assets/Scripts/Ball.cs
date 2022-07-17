using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Shoot shooty;
    [SerializeField] ParticleSystem ps;
    Vector3 vecForward = Vector3.forward;

    private void Update()
    {
        Release();
        PullDownForce();
    }

    void Release()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.parent = null;
        }
    }
    [SerializeField] int mass;
    Vector3 vecZero = Vector3.zero;

   
    void PullDownForce()
    {
        if (transform.position.y > 1 && !(Input.GetMouseButton(0)))
        {
            transform.Translate(vecZero * 20 * Time.deltaTime / mass);
        }
    }
}
