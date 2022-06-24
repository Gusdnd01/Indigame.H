using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObjectLastBoss : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity += Vector2.up * speed * Time.deltaTime;
    }
}
