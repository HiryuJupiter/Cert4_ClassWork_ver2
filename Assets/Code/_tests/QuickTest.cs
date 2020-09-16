using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QuickTest : MonoBehaviour
{
    public Transform trans;

    Collider2D col;
    Rigidbody2D rb;
    Stopwatch timer = new Stopwatch();
    Vector2 offset = Vector3.zero;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        timer.Start();
        for (int i = 0; i < 10000000; i++)
        {
            //Test 1
            Physics2D.Raycast(rb.position + offset, Vector3.up, 0.1f); //6.07 6.9 7.0

            //Test 2
            //Physics2D.Raycast(trans.position, Vector3.up, 0.1f); //5.81s 5.87s 5.88s

            //Test 2
            //Physics2D.Raycast((Vector2)transform.position + offset, Vector3.up, 0.1f); //6.3 6.4 6.9 7.2
        }

        timer.Stop();
        print(timer.Elapsed);
    }

}
