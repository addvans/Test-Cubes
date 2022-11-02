using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    float Distance = 10;
    float Speed = 1;
    Vector3 startpos;
    public void SetParams(float dist = 10, float speed = 1)
    {
        Distance = dist;
        Speed = speed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startpos = transform.position;
    }


    void Update()
    {
        Vector3 vc = transform.right * Speed;
        vc.y = rb.velocity.y;
        rb.velocity = vc;
        if (Vector3.Distance(startpos, transform.position) > Distance)
        {
            var a = transform.GetChild(0);
            a.parent = null;
            a.gameObject.SetActive(true);
            Destroy(a.gameObject, 0.5f);
            Destroy(gameObject);
        }
    }
}
